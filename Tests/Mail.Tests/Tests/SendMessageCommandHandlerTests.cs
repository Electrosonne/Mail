// ------------------------------------------------------------
// <copyright file="SendMessageCommandHandlerTests.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mail.Tests
{
    /// <summary>
    /// Tests for <see cref="SendMessageCommandHandler"/>.
    /// </summary>
    public class SendMessageCommandHandlerTests : TestBase
    {
        /// <summary>
        /// Success send message.
        /// </summary>
        /// <returns>Task.</returns>
        [Fact]
        public async Task SendMessageCommandHandler_Success()
        {
            // Arrange
            var handler = new SendMessageCommandHandler(this.Context, null);
            var command = new SendMessageCommand()
            {
                Body = "Test",
                Subject = string.Empty,
                Recipients = new[] { "test@gmail.com" },
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }
    }
}
