// ------------------------------------------------------------
// <copyright file="SendMessageCommandValidator.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using FluentValidation;

namespace Mail.Application.Commands
{
    /// <summary>
    /// Validation for <see cref="SendMessageCommand"/>.
    /// </summary>
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendMessageCommandValidator"/> class.
        /// </summary>
        public SendMessageCommandValidator()
        {
            this.RuleFor(message => message.Body).NotEmpty().WithMessage("Body must not be empty");
            this.RuleFor(message => message.Subject).NotEmpty().WithMessage("Subject must not be empty");
            this.RuleFor(message => message.Recipients).NotEmpty().WithMessage("Recipients must not be empty");
        }
    }
}
