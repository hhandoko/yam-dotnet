// -----------------------------------------------------------------------
// <copyright file="IMessageClient.cs" company="YamNet">
//   Copyright (c) YamNet 2014 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;

    /// <summary>
    /// The MessageClient interface.
    /// </summary>
    public interface IMessageClient
    {
        /// <summary>
        /// Get all public messages in the User's network. 
        /// Corresponds to "All" conversations in the Yammer web interface.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetAll(int limit, MessageQueryTrim trim, MessageQueryThread thread);

        /// <summary>
        /// Get the User's feed based on the selection made between "Following" and "Top" conversation.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetFeed(int limit, MessageQueryTrim trim, MessageQueryThread thread);

        /// <summary>
        /// Get the algorithmic feed that corresponds to "Top" conversation.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetTop(int limit, MessageQueryTrim trim, MessageQueryThread thread);

        /// <summary>
        /// Get the "Following" feed which is conversations involving people, groups and topics that the user is following.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetFollowing(int limit, MessageQueryTrim trim, MessageQueryThread thread);

        /// <summary>
        /// Get all messages sent by the User. 
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetSent(int limit, MessageQueryTrim trim, MessageQueryThread thread);

        /// <summary>
        /// Get all private messages received by the User.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetPrivate(int limit, MessageQueryTrim trim, MessageQueryThread thread);

        /// <summary>
        /// Get all messages received by the User.
        /// </summary>
        /// <param name="limit">The returned message limit.</param>
        /// <param name="trim">The returned message trim / limit options.</param>
        /// <param name="thread">The thread options.</param>
        /// <returns>The <see cref="IQueryable"/>.</returns>
        IQueryable<Message> GetReceived(int limit, MessageQueryTrim trim, MessageQueryThread thread);
    }
}
