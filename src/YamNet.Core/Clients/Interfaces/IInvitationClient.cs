// -----------------------------------------------------------------------
// <copyright file="IInvitationClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// The InvitationClient interface.
    /// </summary>
    public interface IInvitationClient
    {
        /// <summary>
        /// Invite user(s) to the current user's Yammer network.
        /// </summary>
        /// <param name="emails">The email(s).</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task Invite(string[] emails);
    }
}
