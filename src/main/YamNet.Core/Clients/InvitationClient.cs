// -----------------------------------------------------------------------
// <copyright file="InvitationClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Yammer invitations client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-invitations
    /// </remarks>
    public class InvitationClient : ClientBase, IInvitationClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvitationClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public InvitationClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Invite user(s) to the current user's Yammer network.
        /// </summary>
        /// <param name="emails">The email(s).</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task Invite(string[] emails)
        {
            const int Limit = 20;

            var counter = 1;
            var total = emails.Count();
            var invitees = new Dictionary<string, string>();

            // Send the invitations 20 emails at a time
            for (var i = 0; i < total; i++)
            {
                invitees.Add(string.Format("email{0}", counter), emails[i]);

                if (counter == Limit || i + 1 == total)
                {
                    var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Invitations), invitees.SerializeQueryString());
                    await this.Client.PostAsync(url);

                    counter = 1;
                    invitees.Clear();
                }
                else
                {
                    counter++;
                }
            }
        }
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Invitations endpoint.
        /// </summary>
        public const string Invitations = "/invitations";
    }
}
