// -----------------------------------------------------------------------
// <copyright file="IResponseErrorHandler.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Threading.Tasks;

    using RestSharp;

    /// <summary>
    /// The ResponseErrorHandler interface.
    /// </summary>
    public interface IResponseErrorHandler
    {
        /// <summary>
        /// Throws exceptions for known error types
        /// so they can be handled properly, if desired.
        /// </summary>
        /// <param name="response">The HTTP response message.</param>
        /// <returns>The <see cref="Task{Exception}"/>.</returns>
        Task<Exception> HandleAsync(RestResponse response);
    }
}
