// ------------------------------------------------------------
// <copyright file="SendMessageCommandHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Mail.Application.Commands
{
    /// <summary>
    /// Send message command handler.
    /// </summary>
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, bool>
    {
        /// <summary>
        /// Mail database context.
        /// </summary>
        private readonly IMailDbContext context;

        /// <summary>
        /// Configuration of mail and smtp client.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageCommandHandler"/> class.
        /// </summary>
        /// <param name="context">IMailDbContext.</param>
        /// <param name="configuration">Configuration.</param>
        public SendMessageCommandHandler(IMailDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        /// <summary>
        /// Handle.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>Id.</returns>
        public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var recipients = new List<User>();

            for (int i = 0; i < request.Recipients.Length; i++)
            {
                var recipient = request.Recipients[i];

                User user = this.context.Users.Where(u => u.Email.Equals(recipient)).FirstOrDefault();
                if (user == null)
                {
                    user = new User() { Email = recipient };
                    this.context.Users.Add(user);
                }

                recipients.Add(user);
            }

            Message message = new Message()
            {
                Body = request.Body,
                Subject = request.Subject,
                Recipients = recipients,
                SentDate = DateTime.Now,
            };

            await this.SendEmailAsync(message);

            this.context.Messages.Add(message);
            await this.context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Send email async.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>Success.</returns>
        private async Task SendEmailAsync(Message message)
        {
            try
            {
                using (var mailMessage = new MailMessage(this.configuration["MailConfigure:From"], message.Recipients[0].Email, message.Subject, message.Body))
                {
                    for (int i = 1; i < message.Recipients.Count; i++)
                    {
                        mailMessage.To.Add(message.Recipients[i].Email);
                    }

                    SmtpClient smtp = new SmtpClient(this.configuration["MailConfigure:Host"], Convert.ToInt32(this.configuration["MailConfigure:Port"]))
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(this.configuration["MailConfigure:UserName"], this.configuration["MailConfigure:Password"]),
                    };

                    await smtp.SendMailAsync(mailMessage);
                    message.Result = SentResult.OK;
                }
            }
            catch (Exception e)
            {
                message.Result = SentResult.Failed;
                message.FailedMessage = e.Message;
            }
        }
    }
}
