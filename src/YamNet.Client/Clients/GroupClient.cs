// -----------------------------------------------------------------------
// <copyright file="GroupClient.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    /// <summary>
    /// Yammer group membership client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-groups
    /// </remarks>
    public class GroupClient : ClientBase, IGroupClient
    {
        /// <summary>
        /// The group membership client base uri.
        /// </summary>
        private const string BaseUri = "/group_memberships";

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public GroupClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Join the group specified by the numeric Id.
        /// </summary>
        /// <param name="id">The group id.</param>
        public void Join(int id)
        {
            var url = this.GetFinalUrl(string.Format("{0}.json?group_id={1}", BaseUri, id));

            this.Client.PostAsync(url);
        }

        /// <summary>
        /// Leave the group specified by the numeric Id.
        /// </summary>
        /// <param name="id">The group id.</param>
        public void Leave(int id)
        {
            var url = this.GetFinalUrl(string.Format("{0}.json?group_id={1}", BaseUri, id));

            this.Client.DeleteAsync(url);
        }
    }
}
