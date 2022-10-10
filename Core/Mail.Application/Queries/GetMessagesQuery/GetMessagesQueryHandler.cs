// ------------------------------------------------------------
// <copyright file="GetMessagesQueryHandler.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Mail.Application.Queries
{
    /// <summary>
    /// Get messages query handler.
    /// </summary>
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQuery, IList>
    {
        /// <summary>
        /// Mail database context.
        /// </summary>
        private readonly IMailDbContext context;

        /// <summary>
        /// Mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMessagesQueryHandler"/> class.
        /// </summary>
        /// <param name="context">IMailDbContext.</param>
        /// <param name="mapper">Mapper.</param>
        public GetMessagesQueryHandler(IMailDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handle.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="cancellationToken">CancellationToken.</param>
        /// <returns>Id.</returns>
        public async Task<IList> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
        {
            return await this.context.Messages.Include(u => u.Recipients).ProjectTo<GetMessagesMessageVm>(this.mapper.ConfigurationProvider).ToListAsync();
        }
    }
}