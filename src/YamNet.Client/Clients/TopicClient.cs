// -----------------------------------------------------------------------
// <copyright file="TopicClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// Yammer message topic client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-messages
    /// </remarks>
    public class TopicClient : ClientBase, ITopicClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public TopicClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Get a message topic by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Topic"/>.</returns>
        public async Task<Topic> GetById(long id)
        {
            var url = this.GetFinalUrl(string.Format("{0}/{1}.json", Endpoints.Topics, id));
            var result = await this.Client.GetAsync<Topic>(url);

            return result.Content;
        }
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Topics endpoint.
        /// </summary>
        public const string Topics = "/topics";
    }
}
