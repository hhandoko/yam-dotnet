// -----------------------------------------------------------------------
// <copyright file="ErrorToExceptionTranslator.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Errors
{
    using System;
    using System.Net;

    using YamNet.Client.Exceptions;

    /// <summary>
    /// Translates Yammer API error bodies (mostly 401)
    /// into more granular exceptions.
    /// </summary>
    public class ErrorToExceptionTranslator : IErrorToExceptionTranslator
    {
        /// <summary>
        /// Translates the specified status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="error">The error.</param>
        /// <returns>The exception.</returns>
        /// <remarks>
        /// These codes hang out in api_messages.yml
        /// </remarks>
        public Exception Translate(HttpStatusCode status, Error error)
        {
            switch (error.Code)
            {
                case 4:
                    // User account deactivated, log them out
                    // TODO: this should show them a message to explain WHY
                    return new AccountDeactivatedException();

                case 16:
                    return new TokenNotFoundException();

                case 17:
                    return new ForbiddenException();

                //case 32:

                case 33:
                    return new RateLimitExceededException();

                default:
                    return null;
            }
        }
    }
}
