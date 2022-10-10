// ------------------------------------------------------------
// <copyright file="TestBase.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

using Mail.Database;
using System;

namespace Mail.Tests
{
    /// <summary>
    /// Base testing class.
    /// </summary>
    public abstract class TestBase : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestBase"/> class.
        /// </summary>
        public TestBase()
        {
            this.Context = MailTestFactory.Create();
        }

        /// <summary>
        /// Gets or sets MailDbContext.
        /// </summary>
        protected MailDbContext Context { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            MailTestFactory.Destroy(this.Context);
        }
    }
}
