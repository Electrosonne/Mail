﻿// ------------------------------------------------------------
// <copyright file="DependencyInjection.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mail.Application
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
        /// <returns>Services with MediatR.</returns>
        public static IServiceCollection AddApplication(
           this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
