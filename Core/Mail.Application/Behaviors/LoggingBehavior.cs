// ------------------------------------------------------------
// <copyright file="LoggingBehavior.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Mail.Application
{
    /// <summary>
    /// Logging behavior.
    /// </summary>
    /// <typeparam name="TRequest">Request.</typeparam>
    /// <typeparam name="TResponse">Responce.</typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingBehavior{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Handle of logging.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="next">Next delegate in pipeline of handling request.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>Response.</returns>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).FullName;
            this.logger.LogInformation($"Start of request {requestName}");
            var response = await next();
            this.logger.LogInformation($"End of request {requestName}");
            return response;
        }
    }
}
