// -----------------------------------------------------------------------
// <copyright file="ITopicClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// The TopicClient interface.
    /// </summary>
    public interface ITopicClient
    {
        /// <summary>
        /// Get a topic by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Topic"/>.</returns>
        Task<Topic> GetById(long id);
    }
}
