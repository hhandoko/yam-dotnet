// -----------------------------------------------------------------------
// <copyright file="HttpResponseHandler.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Threading.Tasks;

    using RestSharp;

    /// <summary>
    /// The HTTP response handler.
    /// </summary>
    public class HttpResponseHandler
    {
        /// <summary>
        /// The deserializer.
        /// </summary>
        private readonly IDeserializer deserializer;

        /// <summary>
        /// The response error handler.
        /// </summary>
        private readonly IResponseErrorHandler responseHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseHandler"/> class.
        /// </summary>
        /// <param name="deserializer">The deserializer.</param>
        /// <param name="responseHandler">The response error handler.</param>
        public HttpResponseHandler(IDeserializer deserializer, IResponseErrorHandler responseHandler)
        {
            this.deserializer = deserializer;
            this.responseHandler = responseHandler;
        }

        /// <summary>
        /// Handle HTTP response asynchronously.
        /// </summary>
        /// <param name="response">The HTTP response.</param>
        /// <typeparam name="T">The response class type.</typeparam>
        /// <returns>The <see cref="Task{BaseEnvelope}"/>.</returns>
        public async Task<IBaseEnvelope<T>> HandleResponseAsync<T>(RestResponse response)
            where T : class
        {
            Exception exception = null;
            
            var result = new BaseEnvelope<T>();

            if (!response.IsSuccessStatusCode())
            {
                // This should throw an exception for known errors.
                // No I/O or long task here, calling for result sync is cheaper.
                exception = await this.responseHandler.HandleAsync(response);
            }

            // No known errors, try and capture generic errors.
            if (exception != null)
            {
                result.Exception = exception;
            }
            else
            {
                try
                {
                    // Throw a generic exception for anything other than 200 OK.
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            // No errors, then deserialize content.
            if (exception != null)
            {
                result.Exception = exception;
            }
            else
            {
                var content = response.Content;

                result.Content = this.deserializer.Deserialize<T>(content);
            }

            return result;
        }
    }
}
