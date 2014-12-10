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
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-notifications
    /// </remarks>
    public class NotificationClient : ClientBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public NotificationClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Get current user's relationship.
        /// </summary>
        /// <returns>The <see cref="Relationship"/>.</returns>
        public async Task<Relationship> Get()
        {
            var query = new RelationshipQuery(null, null);
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Relationships), query.SerializeQueryString());
            var result = await this.Client.GetAsync<Relationship>(url);

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
