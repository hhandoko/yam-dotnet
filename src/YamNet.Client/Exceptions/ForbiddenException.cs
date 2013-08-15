// -----------------------------------------------------------------------
// <copyright file="ForbiddenException.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// The access forbidden exception.
    /// </summary>
    /// <remarks>
    /// HTTP returns a 403.
    /// Exception is caught and the user should be logged out.
    /// </remarks>
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        public ForbiddenException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="statusCode">The status code.</param>
        public ForbiddenException(string message, HttpStatusCode statusCode)
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