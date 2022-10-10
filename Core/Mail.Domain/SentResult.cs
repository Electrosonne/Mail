// ------------------------------------------------------------
// <copyright file="SentResult.cs" company="ElectroSonne">
// Copyright (c) ElectroSonne, Russia, 2022.
// </copyright>
// ------------------------------------------------------------

namespace Mail.Domain
{
    /// <summary>
    /// Result of sending.
    /// </summary>
    public enum SentResult
    {
        /// <summary>
        /// Sent successfully.
        /// </summary>
        OK,

        /// <summary>
        /// Sent fail.
        /// </summary>
        Failed,
    }
}
