// ------------------------------------------------------------
// <copyright file="GetMessagesQueryHandlerTests.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Application.Queries;
using Mail.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mail.Tests
{
    /// <summary>
    /// Tests for <see cref="GetMessagesQueryHandler"/>.
    /// </summary>
    public class GetMessagesQueryHandlerTests : TestBase
    {
        /// <summary>
        /// Success get messages.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task GetMessagesQueryHandler_Success()
        {
            // Arrange
            var handler = new GetMessagesQueryHandler(this.Context, MailTestFactory.CreateMapper());

            var user = new GetMessagesRecipientVm() { Email = "andrew@gmail.com" };
            var message = new GetMessagesMessageVm()
            {
                Body = "Hello World!",
                Subject = "Pretty",
                SentDate = new DateTime(2022, 10, 10),
                Recipients = new GetMessagesRecipientVm[] { user },
                Result = "OK",
            };
            var expected = new List<GetMessagesMessageVm>() { message };

            // Act
            var result = await handler.Handle(new GetMessagesQuery(), CancellationToken.None);

            // Assert
            var obj1 = JsonConvert.SerializeObject(expected);
            var obj2 = JsonConvert.SerializeObject(result);
            Assert.Equal(obj1, obj2);
        }
    }
}
