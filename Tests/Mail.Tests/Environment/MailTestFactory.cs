// ------------------------------------------------------------
// <copyright file="MailTestFactory.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Mail.Application;
using Mail.Database;
using Mail.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Mail.Tests
{
    /// <summary>
    /// Factory for unit-testing.
    /// </summary>
    public class MailTestFactory
    {
        /// <summary>
        /// Create database in memory context.
        /// </summary>
        /// <returns>MailDbContext.</returns>
        public static MailDbContext Create()
        {
            var options = new DbContextOptionsBuilder<MailDbContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new MailDbContext(options);
            context.Database.EnsureCreated();

            var user = new User() { Email = "andrew@gmail.com" };
            var message = new Message()
            {
                Body = "Hello World!",
                Subject = "Pretty",
                SentDate = new DateTime(2022, 10, 10),
                Recipients = new List<User>() { user },
                Result = SentResult.OK,
            };

            context.Users.Add(user);
            context.Messages.Add(message);
            context.SaveChanges();
            return context;
        }

        /// <summary>
        /// Destroy database context.
        /// </summary>
        /// <param name="context">MailDbContext.</param>
        public static void Destroy(MailDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        /// <summary>
        /// Create mapper.
        /// </summary>
        /// <returns>Mapper.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(config => { config.AddProfile(new AssemblyMappingProfile(typeof(IMailDbContext).Assembly)); });
            return config.CreateMapper();
        }
    }
}
