// ------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mail.Database
{
    /// <summary>
    /// Dependency injection.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// AddApplication.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Services with MediatR.</returns>
        public static IServiceCollection AddDatabase(
           this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MailDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IMailDbContext>(provider =>
            {
                return provider.GetService<MailDbContext>();
            });
            return services;
        }
    }
}
