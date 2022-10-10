// ------------------------------------------------------------
// <copyright file="ApiController.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using Mail.Application.Commands;
using Mail.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Server.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    [Route("api")]
    public class ApiController : Controller
    {
        /// <summary>
        /// Mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiController"/> class.
        /// </summary>
        /// <param name="mediator">Mediator.</param>
        /// <param name="mapper">Mapper.</param>
        public ApiController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Send message to recipients.
        /// </summary>
        /// <param name="sendMessage">Send message command.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost("mails")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageCommand sendMessage)
        {
            return this.Ok(await this.mediator.Send(sendMessage));
        }

        /// <summary>
        /// Get messages.
        /// </summary>
        /// <returns>List of messages.</returns>
        [HttpGet("mails")]
        public async Task<IActionResult> GetMessages()
        {
            return this.Ok(await this.mediator.Send(new GetMessagesQuery()));
        }
    }
}
