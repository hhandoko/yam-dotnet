// -----------------------------------------------------------------------
// <copyright file="IGroupClient.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// The GroupClient interface.
    /// </summary>
    public interface IGroupClient
    {
        /// <summary>
        /// Join a group by its id.
        /// </summary>
        /// <param name="id">The group id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task JoinById(long id);

        /// <summary>
        /// Leave a group by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task LeaveById(long id);
    }
}
