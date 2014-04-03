// -----------------------------------------------------------------------
// <copyright file="INetworkClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The NetworkClient interface.
    /// </summary>
    public interface INetworkClient
    {
        /// <summary>
        /// Get the current user's network.
        /// </summary>
        /// <param name="includeSuspended">The option to include the network the user is suspended in.</param>
        /// <param name="excludeOwnMessagesFromUnseen">The option to exclude the user's own messages from the unseen count.</param>
        /// <returns>The <see cref="Network"/>.</returns>
        Task<IQueryable<Network>> Current(bool includeSuspended, bool excludeOwnMessagesFromUnseen);
    }
}
