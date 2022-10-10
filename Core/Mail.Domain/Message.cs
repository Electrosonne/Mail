// ------------------------------------------------------------
// <copyright file="Message.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mail.Domain
{
    /// <summary>
    /// Message sent to recipients.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets unique id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets subject of message.
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets body of message.
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets recipients.
        /// </summary>
        [Required]
        public List<User> Recipients { get; set; }

        /// <summary>
        /// Gets or sets send date.
        /// </summary>
        [Required]
        public DateTime SentDate { get; set; }

        /// <summary>
        /// Gets or sets result of sending.
        /// </summary>
        [Required]
        public SentResult Result { get; set; }

        /// <summary>
        /// Gets or sets failed message.
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
