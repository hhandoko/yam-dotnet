// -----------------------------------------------------------------------
// <copyright file="ResponseErrorHandler.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using YamNet.Client.Errors;
    using YamNet.Client.Exceptions;

    /// <summary>
    /// The HTTP response error handler.
    /// </summary>
    public class ResponseErrorHandler : IResponseErrorHandler
    {
        /// <summary>
        /// The deserializer.
        /// </summary>
        private readonly IDeserializer deserializer;

        /// <summary>
        /// The exception translator.
        /// </summary>
        private readonly IErrorToExceptionTranslator translator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseErrorHandler" /> class.
        /// </summary>
        /// <param name="deserializer">The deserializer.</param>
        /// <param name="translator">The error to exception translator.</param>
        public ResponseErrorHandler(IDeserializer deserializer, IErrorToExceptionTranslator translator)
        {
            this.deserializer = deserializer;
            this.translator = translator;
        }

        /// <summary>
        /// Returns exceptions for known error types
        /// so they can be handled properly, if desired.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <returns>The <see cref="Task{Exception}"/>.</returns>
        /// <exception cref="ServerErrorException">Server error exception.</exception>
        /// <exception cref="ConnectionFailureException">Connection failure exception.</exception>
        public async Task<Exception> HandleAsync(HttpResponseMessage response)
        {
            // Currently the server will return html in this case,
            // so there's nothing useful to do.
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return new ServerErrorException();
            }

            // Yammer API rate limit exceeded
            // Reference: https://developer.yammer.com/restapi/#rest-ratelimits
            if ((int)response.StatusCode == 429)
            {
                return new RateLimitExceededException();
            }

            // No valuable information in the content.
            if (response.StatusCode == HttpStatusCode.GatewayTimeout
                || response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode == HttpStatusCode.RequestTimeout)
            {
                return new ConnectionFailureException();
            }

            // Unauthorised, include in return the message body.
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var msg = await response.Content.ReadAsStringAsync();
                if (msg.Contains("{"))
                {
                    msg = msg.Replace("{", string.Empty).Replace("}", string.Empty);
                }

                return new UnauthorizedException(msg, response.StatusCode);
            }

            // Forbidden, include in return the message body.
            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                var msg = await response.Content.ReadAsStringAsync();
                return new ForbiddenException(msg, response.StatusCode);
            }

            // Check message body for errors.
            var errorResponse = await response.Content.ReadAsByteArrayAsync();
            if (errorResponse == null || errorResponse.Length <= 0)
            {
                return null;
            }

            // Deserialise error in the message body, if found.
            Error err;
            try
            {
                err = this.deserializer.Deserialize<Error>(errorResponse);

                if (err == null)
                {
                    return null;
                }

                if (!err.IsValid())
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    var deserializationError = new Exception(msg);

                    return deserializationError;
                }
            }
            catch (Exception ex)
            {
                return ex;
            }

            // Translate any exception found into error codes.
            var exception = this.translator.Translate(response.StatusCode, err);

            return exception;
        }
    }
}
