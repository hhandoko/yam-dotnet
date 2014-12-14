// -----------------------------------------------------------------------
// <copyright file="IUserClient.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// The UserClient interface.
    /// </summary>
    public interface IUserClient
    {
        /// <summary>
        /// Get users.
        /// </summary>
        /// <param name="page">The result page.</param>
        /// <param name="letter">The letter.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="reverse">The reverse.</param>
        /// <returns>The <see cref="IQueryable{UserFullInfo}"/>.</returns>
        Task<IQueryable<UserFullInfo>> Get(int page, string letter, UserQuerySort sort, bool reverse);

        /// <summary>
        /// Get users who belong to a group.
        /// </summary>
        /// <param name="id">The group id.</param>
        /// <param name="page">The page.</param>
        /// <returns>The <see cref="IQueryable{UserFullInfo}"/>.</returns>
        Task<IQueryable<UserFullInfo>> GetByGroupId(long id, int page);

        /// <summary>
        /// Get a user by their id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="includeFollowed">The include followed users flag.</param>
        /// <param name="includeSubscribedTags">The include subscribed tags flag.</param>
        /// <param name="includeGroups">The include groups membership flag.</param>
        /// <returns>The <see cref="UserFullInfo"/>.</returns>
        Task<UserFullInfo> GetById(long id, bool includeFollowed, bool includeSubscribedTags, bool includeGroups);

        /// <summary>
        /// Get a user by their email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="includeFollowed">The include followed users flag.</param>
        /// <param name="includeSubscribedTags">The include subscribed tags flag.</param>
        /// <param name="includeGroups">The include groups membership flag.</param>
        /// <returns>The <see cref="UserFullInfo"/>.</returns>
        Task<UserFullInfo> GetByEmail(string email, bool includeFollowed, bool includeSubscribedTags, bool includeGroups);

        /// <summary>
        /// Get the current user.
        /// </summary>
        /// <param name="includeFollowed">The include followed users flag.</param>
        /// <param name="includeSubscribedTags">The include subscribed tags flag.</param>
        /// <param name="includeGroups">The include groups membership flag.</param>
        /// <returns>The <see cref="UserFullInfo"/>.</returns>
        Task<UserFullInfo> Current(bool includeFollowed, bool includeSubscribedTags, bool includeGroups);
        
        /// <summary>
        /// Suspend a user by his/her id (i.e. soft-delete).
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task SuspendById(long id);

        /// <summary>
        /// Delete a user by his/her id (i.e. hard / permanent deletion).
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteById(long id);
    }
}
