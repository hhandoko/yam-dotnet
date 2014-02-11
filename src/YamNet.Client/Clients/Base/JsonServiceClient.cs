// -----------------------------------------------------------------------
// <copyright file="JsonServiceClient.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using YamNet.Client.Exceptions;

    /// <summary>
    /// The JSON web service client.
    /// </summary>
    public class JsonServiceClient : IDisposable
    {
        /// <summary>
        /// Denotes whether client has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The http client.
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// The http client handler.
        /// </summary>
        private HttpClientHandler handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonServiceClient"/> class.
        /// </summary>
        /// <param name="token">The access token.</param>
        public JsonServiceClient(string token)
        {
            this.Init(token);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonServiceClient"/> class.
        /// </summary>
        /// <param name="token">The access token.</param>
        /// <param name="proxy">The proxy.</param>
        /// <param name="credentials">The credentials.</param>
        public JsonServiceClient(string token, IWebProxy proxy, ICredentials credentials)
        {
            this.handler = new HttpClientHandler
            {
                UseProxy = true,
                Proxy = proxy,
                UseDefaultCredentials = false,
                Credentials = credentials
            };

            this.Init(token);
        }

        /// <summary>
        /// Gets or sets the serializer.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        /// Gets or sets the deserializer.
        /// </summary>
        public IDeserializer Deserializer { get; set; }

        /// <summary>
        /// Gets or sets the response error handler.
        /// </summary>
        public IResponseErrorHandler ResponseErrorHandler { get; set; }

        /// <summary>
        /// Gets or sets the URI / URL endpoint.
        /// </summary>
        internal Uri Endpoint { get; set; }

        /// <summary>
        /// Post via async.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task<IBaseEnvelope<object>> PostAsync(string uri, object parameters = null)
        {
            return await this.PostAsync<object>(uri, parameters);
        }

        /// <summary>
        /// Post via async.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="T">The class type.</typeparam>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task<IBaseEnvelope<T>> PostAsync<T>(string uri, object parameters = null)
            where T : class
        {
            return await this.ExecuteAsync<T>(HttpMethod.Post, uri, parameters);
        }

        /// <summary>
        /// Get via async.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="T">The class type.</typeparam>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task<IBaseEnvelope<T>> GetAsync<T>(string uri, object parameters = null)
            where T : class
        {
            return await this.ExecuteAsync<T>(HttpMethod.Get, uri, parameters);
        }

        /// <summary>
        /// Delete via async.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task<IBaseEnvelope<object>> DeleteAsync(string uri, object parameters = null)
        {
            return await this.DeleteAsync<object>(uri, parameters);
        }

        /// <summary>
        /// Delete via async.
        /// </summary>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="T">The class type.</typeparam>
        /// <returns>The <see cref="Task"/>.</returns>
        internal async Task<IBaseEnvelope<T>> DeleteAsync<T>(string uri, object parameters = null)
            where T : class
        {
            return await this.ExecuteAsync<T>(HttpMethod.Delete, uri, parameters);
        }

        /// <summary>
        /// Execute via async.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="uri">The uri.</param>
        /// <param name="parameters">The parameters.</param>
        /// <typeparam name="T">The class type.</typeparam>
        /// <returns>The <see cref="Task"/>.</returns>
        protected async Task<IBaseEnvelope<T>> ExecuteAsync<T>(
            HttpMethod method,
            string uri,
            object parameters)
            where T : class
        {
            return await TaskEx.Run(async () =>
            {
                var tryAgain = true;
                var counter = 0;

                var response = default(HttpResponseMessage);
                var result = default(IBaseEnvelope<T>);

                try
                {
                    var request = new HttpRequestObject(this.Serializer);

                    while (tryAgain && counter++ < 3)
                    {
                        try
                        {
                            response =
                                await
                                request.ExecuteRequestAsync<T>(this.client, method, this.Endpoint, uri, parameters);
                            tryAgain = false;
                        }
                        catch (RateLimitExceededException)
                        {
                            Debug.WriteLine("Rate Limit Exceeded");
                        }

                        if (tryAgain)
                        {
                            await TaskEx.Delay(TimeSpan.FromSeconds(10));
                        }
                    }

                    if (!tryAgain)
                    {
                        var responseHandler = new HttpResponseHandler(this.Deserializer, this.ResponseErrorHandler);

                        result = await responseHandler.HandleResponseAsync<T>(response);
                        response.Dispose();
                    }
                }
                catch (AggregateException ae)
                {
                    ae.Flatten().Handle(e =>
                    {
                        if (e.GetType() != typeof(RateLimitExceededException))
                        {
                            result = new BaseEnvelope<T> { Exception = e.InnerException ?? e };
                        }

                        return true;
                    });
                }
                catch (HttpRequestException httpEx)
                {
                    if (httpEx.InnerException is WebException)
                    {
                        var webEx = httpEx.InnerException as WebException;
                        var status = webEx.Status;

                        if (status.ToString() == "NameResolutionFailure")
                        {
                            var offlineException = new OfflineException();

                            result = new BaseEnvelope<T> { Exception = offlineException };
                        }
                    }
                }
                catch (Exception ex)
                {
                    result = new BaseEnvelope<T> { Exception = ex };
                }

                return result;
            });
        }

        /// <summary>
        /// Initialise the service client.
        /// </summary>
        /// <param name="token">The access token.</param>
        private void Init(string token)
        {
            this.client = this.handler == null
                ? new HttpClient()
                : new HttpClient(this.handler);

            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            this.client.Timeout = TimeSpan.FromMinutes(1);
        }

        #region Disposable
        /// <summary>
        /// Finalizes an instance of the <see cref="JsonServiceClient"/> class. 
        /// </summary>
        ~JsonServiceClient()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Dispose the current object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Release managed and, optionally, unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (!disposing)
            {
                if (this.client != null)
                {
                    this.client.Dispose();
                    this.client = null;
                }

                if (this.handler != null)
                {
                    this.handler.Dispose();
                    this.handler = null;
                }

                GC.SuppressFinalize(this);
            }

            // No unmanaged resources to release
            this.disposed = true;
        }
        #endregion
    }
}
