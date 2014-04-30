// -----------------------------------------------------------------------
// <copyright file="MessageClientUndocumented.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Undocumented Yammer messages APIs.
    /// </summary>
    public static class MessageClientUndocumented
    {
        /// <summary>
        /// Get all messages in a group.
        /// </summary>
        /// <param name="client">The message client.</param>
        /// <param name="groupId">The group id.</param>
        /// <param name="thread">The message thread option.</param>
        /// <returns>The <see cref="IQueryable{Message}"/>.</returns>
        public static async Task<IQueryable<Message>> GetByGroup(this MessageClient client, long groupId, MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(0, null, thread);
            var url = client.GetFinalUrl(string.Format("{0}/in_group/{1}.json", Endpoints.Messages, groupId), query.SerializeQueryString());
            var result = await client.Client.GetAsync<MessageEnvelope>(url);

            return result.Content.Messages.AsQueryable();
        }
    }

    /// <summary>
    /// The undocumented MessageClient query helper.
    /// </summary>
    internal class MessageQueryUndocumented : MessageQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageQueryUndocumented"/> class.
        /// </summary>
        /// <param name="threaded">The message thread option.</param>
        /// <param name="excludeOwnMessages">Exclude own messages from unseen count.</param>
        /// <param name="includeCounts">Include message count.</param>
        public MessageQueryUndocumented(
            MessageQueryThread threaded,
            bool? excludeOwnMessages,
            bool? includeCounts)
            : base(0, null, threaded)
        {
            if (excludeOwnMessages != null)
            {
                this.Exclude_Own_Messages_From_Unseen = excludeOwnMessages;
            }

            if (includeCounts != null)
            {
                this.Include_Counts = includeCounts;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether to exclude user's own messages from the unseen count.
        /// </summary>
        /// <remarks>
        /// Exclude the user’s own messages from the unseen count. This is good for unread badges.
        /// </remarks>
        public bool? Exclude_Own_Messages_From_Unseen { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether message counts should be returned.
        /// </summary>
        public bool? Include_Counts { get; set; }
    }
}
