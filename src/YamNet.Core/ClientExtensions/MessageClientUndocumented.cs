// -----------------------------------------------------------------------
// <copyright file="MessageClientUndocumented.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Undocumented
{
    using System.Threading.Tasks;

    /// <summary>
    /// Undocumented Yammer messages APIs.
    /// </summary>
    public static class MessageClientUndocumented
    {
        /// <summary>
        /// Get all messages in a group.
        /// </summary>
        /// <remarks>
        /// UNDOCUMENTED. Use at your own risk.
        /// </remarks>
        /// <param name="client">The message client.</param>
        /// <param name="groupId">The group id.</param>
        /// <param name="thread">The message thread option.</param>
        /// <returns>The <see cref="MessageEnvelope"/>.</returns>
        public static async Task<MessageEnvelope> GetByGroupId(
            this MessageClient client,
            long groupId,
            MessageQueryThread thread = MessageQueryThread.NoThread)
        {
            var query = new MessageQuery(0, null, thread);
            var url = client.GetFinalUrl(string.Format("{0}/in_group/{1}.json", Endpoints.Messages, groupId), query.SerializeQueryString());
            var result = await client.Client.GetAsync<MessageEnvelope>(url);

            return result.Content;
        }
    }
}
