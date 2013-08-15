// -----------------------------------------------------------------------
// <copyright file="Client.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Net;

    /// <summary>
    /// The Yammer web client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The default Yammer REST API endpoint.
        /// </summary>
        private const string DefaultEndpoint = "https://www.yammer.com/api/v1";

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="token">The access token.</param>
        public Client(string token)
        {
            this.Init(token);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="token">The access token.</param>
        /// <param name="proxy">The proxy.</param>
        public Client(string token, IWebProxy proxy)
        {
            this.Proxy = proxy;

            this.Init(token);
        }

        /// <summary>
        /// Gets or sets the users REST API endpoint.
        /// </summary>
        public UserClient Users { get; set; }

        /// <summary>
        /// Gets or sets the REST API endpoint.
        /// </summary>
        internal string Endpoint { get; set; }

        /// <summary>
        /// Gets or sets the bearer token.
        /// </summary>
        internal string BearerToken { get; set; }

        /// <summary>
        /// Gets or sets the web proxy.
        /// </summary>
        internal IWebProxy Proxy { get; set; }

        /// <summary>
        /// Initialise the base client.
        /// </summary>
        /// <param name="token">The access token.</param>
        private void Init(string token)
        {
            this.Endpoint = DefaultEndpoint;
            this.BearerToken = token;

            this.Users = new UserClient(this);
        }
    }
}
