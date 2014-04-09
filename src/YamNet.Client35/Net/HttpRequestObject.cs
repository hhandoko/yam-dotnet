// -----------------------------------------------------------------------
// <copyright file="HttpRequestObject.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Threading.Tasks;

    using RestSharp;

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
        /// <returns>The <see cref="Task{RestRequest}"/>.</returns>
        public async virtual Task<IRestResponse> ExecuteRequestAsync<T>(
            RestClient client,
            Method method,
            Uri baseUri,
            string uri,
            object parameters)
            where T : class
        {
            var completion = new TaskCompletionSource<IRestResponse>();

            await Task.Factory.StartNew(() =>
                {
                    var request = this.CreateRequestMessage(method, baseUri, uri, parameters);

                    client.BaseUrl = baseUri.ToString();
                    client.ExecuteAsync(request, response =>
                        {
                            if (response.ErrorException != null)
                            {
                                completion.TrySetException(response.ErrorException);
                            }
                            else
                            {
                                completion.TrySetResult(response);
                            }
                        });
                });

            return await completion.Task;
        }

        /// <summary>
        /// Create a new HTTP request message.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="baseUri">The base uri (protocol, host, and port).</param>
        /// <param name="uri">The relative uri.</param>
        /// <param name="parameters">The query string parameters.</param>
        /// <returns>The <see cref="RestRequest"/>.</returns>
        protected virtual RestRequest CreateRequestMessage(
            Method method,
            Uri baseUri,
            string uri,
            object parameters)
        {
            // Get the full endpoint URL and create a HTTP request message
            //var endpoint = new UriBuilder(uri.IsUri() ? uri : baseUri + uri);
            var request = new RestRequest(uri, method);
            
            // Queryparams only apply to GET, 
            // and if request has body, use the correct MIME type
            if (!IncludeParametersInUri(method) && parameters != null)
            {
                var content = this.serializer.Serialize(parameters);

                request.AddHeader("Accept", this.serializer.ContentType);
                request.Parameters.Clear();
                request.AddParameter(
                    this.serializer.ContentType,
                    content,
                    ParameterType.RequestBody);
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
        private static bool IncludeParametersInUri(Method method)
        {
            return
                method != Method.POST
                && method != Method.PUT
                && method != Method.DELETE;
        }
    }
}
