// ------------------------------------------------------------
// <copyright file="User.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mail.Domain
{
    /// <summary>
    /// User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets unique id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets messages.
        /// </summary>
        [Required]
        public List<Message> Messages { get; set; }
    }
}
