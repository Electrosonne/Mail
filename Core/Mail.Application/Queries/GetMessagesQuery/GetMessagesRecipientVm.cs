// ------------------------------------------------------------
// <copyright file="GetMessagesRecipientVm.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Mail.Domain;

namespace Mail.Application.Queries
{
    /// <summary>
    /// Recipient view model.
    /// </summary>
    public class GetMessagesRecipientVm : IMapWith<User>
    {
        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mapping.
        /// </summary>
        /// <param name="profile">Profile.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetMessagesRecipientVm>()
                .ForMember(
                    recipientVm => recipientVm.Email,
                    opt => opt.MapFrom(user => user.Email));
        }
    }
}
