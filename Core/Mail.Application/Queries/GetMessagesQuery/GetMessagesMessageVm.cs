// ------------------------------------------------------------
// <copyright file="GetMessagesMessageVm.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Mail.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mail.Application.Queries
{
    /// <summary>
    /// Message view model.
    /// </summary>
    public class GetMessagesMessageVm : IMapWith<Message>
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
        public GetMessagesRecipientVm[] Recipients { get; set; }

        /// <summary>
        /// Gets or sets send date.
        /// </summary>
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Gets or sets result of sending.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets failed message.
        /// </summary>
        public string FailedMessage { get; set; }

        /// <summary>
        /// Mapping.
        /// </summary>
        /// <param name="profile">Profile.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, GetMessagesMessageVm>()
                .ForMember(
                    messageVm => messageVm.Subject,
                    opt => opt.MapFrom(message => message.Subject))
                .ForMember(
                    messageVm => messageVm.Body,
                    opt => opt.MapFrom(message => message.Body))
                .ForMember(
                    messageVm => messageVm.Recipients,
                    opt => opt.MapFrom(message => message.Recipients))
                .ForMember(
                    messageVm => messageVm.SentDate,
                    opt => opt.MapFrom(message => message.SentDate))
                .ForMember(
                    messageVm => messageVm.Result,
                    opt => opt.MapFrom(message => message.Result))
                .ForMember(
                    messageVm => messageVm.FailedMessage,
                    opt => opt.MapFrom(message => message.FailedMessage));
        }
    }
}
