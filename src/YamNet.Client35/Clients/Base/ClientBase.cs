// -----------------------------------------------------------------------
// <copyright file="ClientBase.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using YamNet.Client.Errors;

    /// <summary>
    /// The client base.
    /// </summary>
    public class ClientBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientBase"/> class.
        /// </summary>
        /// <param name="client">The Yammer REST client.</param>
        public ClientBase(Client client)
        {
            this.Client = client.Proxy == null
                ? new JsonServiceClient(client.BearerToken)
                : new JsonServiceClient(client.BearerToken, client.Proxy, client.Proxy.Credentials);

            this.Client.Endpoint = new Uri(client.Endpoint);
            this.Client.Serializer = new JsonDotNetSerializer();
            this.Client.Deserializer = new JsonDotNetDeserializer();
            this.Client.ResponseErrorHandler = new ResponseErrorHandler(new JsonDotNetDeserializer(), new ErrorToExceptionTranslator());
        }

        /// <summary>
        /// Gets or sets the JSON web service client.
        /// </summary>
        public JsonServiceClient Client { get; set; }

        /// <summary>
        /// Get the final url to call the REST API.
        /// </summary>
        /// <param name="baseUri">The base uri.</param>
        /// <param name="urlParams">The url parameters.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetFinalUrl(string baseUri, string urlParams = "")
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(urlParams))
            {
                var separator = baseUri.Contains("?") ? "&" : "?";

                result = string.Format("{0}{1}{2}", baseUri, separator, urlParams);
            }
            else
            {
                result = baseUri;
            }

            return result;
        }
    }
}
