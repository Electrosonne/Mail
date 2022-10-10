// ------------------------------------------------------------
// <copyright file="GetMessagesQuery.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using MediatR;
using System.Collections;

namespace Mail.Application.Queries
{
    /// <summary>
    /// Get messages query.
    /// </summary>
    public class GetMessagesQuery : IRequest<IList>
    {
    }
}
