// -----------------------------------------------------------------------
// <copyright file="IResponseErrorHandler.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// The ResponseErrorHandler interface.
    /// </summary>
    public interface IResponseErrorHandler
    {
        /// <summary>
        /// Throws exceptions for known error types
        /// so they can be handled properly, if desired.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task<Exception> HandleAsync(HttpResponseMessage response);
    }
}
