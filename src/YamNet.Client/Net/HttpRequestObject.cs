// -----------------------------------------------------------------------
// <copyright file="HttpRequestObject.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// The http request object.
    /// </summary>
    internal class HttpRequestObject
    {
        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequestObject"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public HttpRequestObject(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// The execute request async.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="method">The method.</param>
        /// <param name="baseUri">The base uri.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="T">The class.</typeparam>
        /// <returns>The <see cref="Task"/>.</returns>
        public virtual async Task<HttpResponseMessage> ExecuteRequestAsync<T>(
            HttpClient client,
            HttpMethod method,
            Uri baseUri,
            string uri,
            object parameters)
            where T : class
        {
            HttpResponseMessage response = null;

            using (var request = this.CreateRequestMessage(method, baseUri, uri, parameters))
            {
                if (request != null)
                {
                    response = await client.SendAsync(request);
                }
            }

            return response;
        }

        /// <summary>
        /// The create request message.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="baseUri">The base uri.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>
        protected virtual HttpRequestMessage CreateRequestMessage(
            HttpMethod method,
            Uri baseUri,
            string uri,
            object parameters)
        {
            var endpoint = new UriBuilder(uri.IsUri() ? uri : baseUri + uri);

            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = endpoint.Uri
            };

            if (!IncludeParametersInUri(method))
            {
                var content = this.serializer.SerializeToByteArray(parameters);
                request.Content = new ByteArrayContent(content);
            }

            if (request.Content != null)
            {
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.serializer.ContentType);
            }

            return request;
        }

        /// <summary>
        /// Checks if parameters need to be included in the URI (only for GET)
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool IncludeParametersInUri(HttpMethod method)
        {
            return method != HttpMethod.Post
                   && method != HttpMethod.Put
                   && method != HttpMethod.Delete;
        }
    }
}
