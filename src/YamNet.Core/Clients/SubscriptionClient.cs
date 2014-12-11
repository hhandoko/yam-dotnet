// -----------------------------------------------------------------------
// <copyright file="SubscriptionClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Yammer user's subscription client.
    /// Manage subscriptions to topics, threads, and users.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-notifications
    /// </remarks>
    public class SubscriptionClient : ClientBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public SubscriptionClient(Client client) : base(client)
        {
        }
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Notifications endpoint.
        /// </summary>
        public const string Subscriptions = "/subscriptions";
    }
}
