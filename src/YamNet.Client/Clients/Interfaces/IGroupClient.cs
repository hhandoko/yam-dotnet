// -----------------------------------------------------------------------
// <copyright file="IGroupClient.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    /// <summary>
    /// The GroupClient interface.
    /// </summary>
    public interface IGroupClient
    {
        /// <summary>
        /// Join a group.
        /// </summary>
        /// <param name="id">The group id.</param>
        void Join(int id);

        /// <summary>
        /// Leave a group.
        /// </summary>
        /// <param name="id">The id.</param>
        void Leave(int id);
    }
}
