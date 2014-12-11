// -----------------------------------------------------------------------
// <copyright file="Client.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Net;

    /// <summary>
    /// The Yammer web client.
    /// </summary>
    public class Client : IDisposable
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
        /// Gets the group memberships REST API endpoint.
        /// </summary>
        public GroupClient Groups { get; private set; }

        /// <summary>
        /// Gets the invitations REST API endpoint.
        /// </summary>
        public InvitationClient Invitations { get; private set; }
        
        /// <summary>
        /// Gets the messages REST API endpoint.
        /// </summary>
        public MessageClient Messages { get; private set; }

        /// <summary>
        /// Gets the network REST API endpoint.
        /// </summary>
        public NetworkClient Networks { get; private set; }

        /// <summary>
        /// Gets the user's relationship REST API endpoint.
        /// </summary>
        public RelationshipClient Relationships { get; private set; }

        /// <summary>
        /// Gets the search REST API endpoint.
        /// </summary>
        public SearchClient Search { get; private set; }

        /// <summary>
        /// Gets the message topic REST API endpoint.
        /// </summary>
        public TopicClient Topics { get; private set; }

        /// <summary>
        /// Gets the users REST API endpoint.
        /// </summary>
        public UserClient Users { get; private set; }

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
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            if (this.Groups.Client != null)
            {
                this.Groups.Client.Dispose();
            }

            if (this.Invitations.Client != null)
            {
                this.Invitations.Client.Dispose();
            }

            if (this.Messages.Client != null)
            {
                this.Messages.Client.Dispose();
            }

            if (this.Networks.Client != null)
            {
                this.Networks.Client.Dispose();
            }

            if (this.Relationships.Client != null)
            {
                this.Relationships.Client.Dispose();
            }

            if (this.Search.Client != null)
            {
                this.Search.Client.Dispose();
            }

            if (this.Topics.Client != null)
            {
                this.Topics.Client.Dispose();
            }

            if (this.Users.Client != null)
            {
                this.Users.Client.Dispose();
            }
        }

        /// <summary>
        /// Initialise the base client.
        /// </summary>
        /// <param name="token">The access token.</param>
        private void Init(string token)
        {
            this.Endpoint = DefaultEndpoint;
            this.BearerToken = token;

            this.Groups = new GroupClient(this);
            this.Invitations = new InvitationClient(this);
            this.Messages = new MessageClient(this);
            this.Networks = new NetworkClient(this);
            this.Relationships = new RelationshipClient(this);
            this.Search = new SearchClient(this);
            this.Topics = new TopicClient(this);
            this.Users = new UserClient(this);
        }
    }
}
