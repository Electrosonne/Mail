// ------------------------------------------------------------
// <copyright file="IMailDbContext.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mail.Application
{
    /// <summary>
    /// Chat database context.
    /// </summary>
    public interface IMailDbContext
    {
        /// <summary>
        /// Gets or sets messages.
        /// </summary>
        DbSet<Message> Messages { get; set; }

        /// <summary>
        /// Gets or sets users.
        /// </summary>
        DbSet<User> Users { get; set; }

        /// <summary>
        /// Save changes asynchronously.
        /// </summary>
        /// <returns>Task.</returns>
        Task SaveChangesAsync();
    }
}
