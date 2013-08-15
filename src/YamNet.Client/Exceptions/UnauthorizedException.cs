// -----------------------------------------------------------------------
// <copyright file="UnauthorizedException.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// The unauthorized exception.
    /// </summary>
    public class UnauthorizedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        public UnauthorizedException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }
    }
}
