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
        /// Join a group by its id.
        /// </summary>
        /// <param name="id">The group id.</param>
        void JoinById(long id);

        /// <summary>
        /// Leave a group by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        void LeaveById(long id);
    }
}
