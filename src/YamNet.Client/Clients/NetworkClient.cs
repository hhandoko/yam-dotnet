// -----------------------------------------------------------------------
// <copyright file="GroupClient.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Yammer network client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-networks
    /// </remarks>
    public class NetworkClient : ClientBase, INetworkClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public NetworkClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Get the current user's network.
        /// </summary>
        /// <param name="includeSuspended">The option to include the network the user is suspended in.</param>
        /// <param name="excludeOwnMessagesFromUnseen">The option to exclude the user's own messages from the unseen count.</param>
        /// <returns>The <see cref="Network"/>.</returns>
        public async Task<IQueryable<Network>> Current(bool includeSuspended = true, bool excludeOwnMessagesFromUnseen = true)
        {
            var query = new NetworkQuery(includeSuspended, excludeOwnMessagesFromUnseen);
            var url = this.GetFinalUrl(string.Format("{0}/current.json", Endpoints.Networks), query.SerializeQueryString());
            var result = await this.Client.GetAsync<Network[]>(url);

            return result.Content.AsQueryable();
        }
    }

    /// <summary>
    /// The NetworkClient query helper.
    /// </summary>
    internal class NetworkQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserQuery"/> class.
        /// </summary>
        /// <param name="includeSuspended">The option to include the network the user is suspended in.</param>
        /// <param name="excludeOwnMessagesFromUnseen">The option to exclude the user's own messages from the unseen count.</param>
        public NetworkQuery(
            bool includeSuspended,
            bool excludeOwnMessagesFromUnseen)
        {
            if (includeSuspended == false)
            {
                this.Include_Suspended = false;
            }

            if (excludeOwnMessagesFromUnseen == false)
            {
                this.Exclude_Own_Messages_From_Unseen = false;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to include networks user suspended in.
        /// </summary>
        /// <remarks>
        /// Include networks user suspended in.
        /// </remarks>
        public bool? Include_Suspended { get; set; }
        
        /// <summary>
        /// Gets or sets the value indicating whether to exclude user's own messages from the unseen count.
        /// </summary>
        /// <remarks>
        /// Exclude the user’s own messages from the unseen count. This is good for unread badges.
        /// </remarks>
        public bool? Exclude_Own_Messages_From_Unseen { get; set; }
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Networks endpoint.
        /// </summary>
        public const string Networks = "/networks";
    }
}
