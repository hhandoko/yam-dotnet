// -----------------------------------------------------------------------
// <copyright file="NotificationClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// Yammer user's notification client.
    /// Get the notifications feed for the current user.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-notifications
    /// </remarks>
    public class NotificationClient : ClientBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public NotificationClient(Client client) : base(client)
        {
        }

        /// <summary>
        /// Get current user's notifications.
        /// </summary>
        /// <returns>The <see cref="NotificationEnvelope"/>.</returns>
        public async Task<NotificationEnvelope> Get()
        {
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Notifications));
            var result = await this.Client.GetAsync<NotificationEnvelope>(url);

            return result.Content;
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
        public const string Notifications = "/streams/notifications";
    }
}
