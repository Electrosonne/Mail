// ------------------------------------------------------------
// <copyright file="MailDbContext.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Application;
using Mail.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mail.Database
{
    /// <summary>
    /// Chat database context implementation.
    /// </summary>
    public class MailDbContext : DbContext, IMailDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailDbContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public MailDbContext(DbContextOptions<MailDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        /// <inheritdoc/>
        public DbSet<Message> Messages { get; set; }

        /// <inheritdoc/>
        public DbSet<User> Users { get; set; }

        /// <inheritdoc/>
        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
