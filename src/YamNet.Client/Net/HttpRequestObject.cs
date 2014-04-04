// -----------------------------------------------------------------------
// <copyright file="HttpRequestObject.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// The HTTP request object.
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
        /// Execute HTTP request asynchronously.
        /// </summary>
        /// <param name="client">The HTTP client.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="baseUri">The base uri (protocol, host, and port).</param>
        /// <param name="uri">The relative uri.</param>
        /// <param name="parameters">The query string parameters.</param>
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
            using (var request = this.CreateRequestMessage(method, baseUri, uri, parameters))
            {
                return
                    request == null
                        ? null
                        : await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            }
        }

        /// <summary>
        /// Create a new HTTP request message.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="baseUri">The base uri (protocol, host, and port).</param>
        /// <param name="uri">The relative uri.</param>
        /// <param name="parameters">The query string parameters.</param>
        /// <returns>The <see cref="HttpRequestMessage"/>.</returns>
        protected virtual HttpRequestMessage CreateRequestMessage(
            HttpMethod method,
            Uri baseUri,
            string uri,
            object parameters)
        {
            // Get the full endpoint URL and create a HTTP request message
            var endpoint = new UriBuilder(uri.IsUri() ? uri : baseUri + uri);
            var request =
                new HttpRequestMessage
                    {
                        Method = method,
                        RequestUri = endpoint.Uri
                    };

            // Queryparams only apply to GET
            if (!IncludeParametersInUri(method))
            {
                var content = this.serializer.SerializeToByteArray(parameters);
                request.Content = new ByteArrayContent(content);
            }

            // If request has body, use the correct MIME type
            if (request.Content != null)
            {
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(this.serializer.ContentType);
            }

            return request;
        }

        /// <summary>
        /// Checks if parameters need to be included in the URI.
        /// Query params only applicable for GET,
        /// otherwise it must be passed along in the form-body.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool IncludeParametersInUri(HttpMethod method)
        {
            return
                method != HttpMethod.Post
                && method != HttpMethod.Put
                && method != HttpMethod.Delete;
        }
    }
}
