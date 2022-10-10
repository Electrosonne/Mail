// ------------------------------------------------------------
// <copyright file="SendMessageCommand.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using MediatR;

namespace Mail.Application.Commands
{
    /// <summary>
    /// Send message command.
    /// </summary>
    public class SendMessageCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets subject of message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets body of message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets recipients.
        /// </summary>
        public string[] Recipients { get; set; }
    }
}
