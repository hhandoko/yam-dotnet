// -----------------------------------------------------------------------
// <copyright file="IErrorToExceptionTranslator.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Errors
{
    using System;
    using System.Net;

    /// <summary>
    /// The ResponseErrorHandler interface.
    /// </summary>
    public interface IErrorToExceptionTranslator
    {
        /// <summary>
        /// Translate error bodies into more granular exceptions.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="error">The error.</param>
        /// <returns>The <see cref="Exception"/>.</returns>
        Exception Translate(HttpStatusCode statusCode, Error error);
    }
}
