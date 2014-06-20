// -----------------------------------------------------------------------
// <copyright file="UserClient.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    using Config = ClientConfiguration;

    /// <summary>
    /// Yammer users' client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-users
    /// </remarks>
    public class UserClient : ClientBase, IUserClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public UserClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Get users in the network, with optional filters.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="letter">The letter.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="reverse">True to return results in reverse order.</param>
        /// <returns>The <see cref="IQueryable{User}"/>.</returns>
        public async Task<IQueryable<User>> Get(int page = Config.DefaultPageNo, string letter = "", UserQuerySort sort = UserQuerySort.NoSort, bool reverse = false)
        {
            var query = new UserQuery(page, letter, sort, reverse, false, false, false);
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Users), query.SerializeQueryString());
            var result = await this.Client.GetAsync<User[]>(url);

            return result.Content.AsQueryable();
        }

        /// <summary>
        /// Get users who belong to a group.
        /// </summary>
        /// <param name="id">The group id.</param>
        /// <param name="page">The page.</param>
        /// <returns>The <see cref="IQueryable{User}"/>.</returns>
        public async Task<IQueryable<User>> GetByGroupId(long id, int page = Config.DefaultPageNo)
        {
            var query = new UserQuery(page, string.Empty, UserQuerySort.NoSort, false, false, false, false);
            var url = this.GetFinalUrl(string.Format("{0}/in_group/{1}.json", Endpoints.Users, id), query.SerializeQueryString());
            var result = await this.Client.GetAsync<GroupUser>(url);

            return result.Content.Users.AsQueryable();
        }

        /// <summary>
        /// Get a user by his/her id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="includeFollowed">True to include followed users.</param>
        /// <param name="includeSubscribedTags">True to include subscribed tags.</param>
        /// <param name="includeGroups">True to include group memberships.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public async Task<User> GetById(long id, bool includeFollowed = false, bool includeSubscribedTags = false, bool includeGroups = false)
        {
            var query = new UserQuery(0, string.Empty, UserQuerySort.NoSort, false, includeFollowed, includeSubscribedTags, includeGroups);
            var url = this.GetFinalUrl(string.Format("{0}/{1}.json", Endpoints.Users, id), query.SerializeQueryString());
            var result = await this.Client.GetAsync<User>(url);

            return result.Content;
        }

        /// <summary>
        /// Get a user by his/her email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="includeFollowed">True to include followed users.</param>
        /// <param name="includeSubscribedTags">True to include subscribed tags.</param>
        /// <param name="includeGroups">True to include group memberships.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public async Task<User> GetByEmail(string email, bool includeFollowed = false, bool includeSubscribedTags = false, bool includeGroups = false)
        {
            var query = new UserQuery(0, string.Empty, UserQuerySort.NoSort, false, includeFollowed, includeSubscribedTags, includeGroups);
            var url = this.GetFinalUrl(string.Format("{0}/by_email.json?email={1}", Endpoints.Users, email), query.SerializeQueryString());
            var result = await this.Client.GetAsync<User[]>(url);

            return result.Content.FirstOrDefault();
        }

        /// <summary>
        /// Get the current logged-in user.
        /// </summary>
        /// <param name="includeFollowed">True to include followed users.</param>
        /// <param name="includeSubscribedTags">True to include subscribed tags.</param>
        /// <param name="includeGroups">True to include group memberships.</param>
        /// <returns>The <see cref="User"/>.</returns>
        public async Task<User> Current(bool includeFollowed = false, bool includeSubscribedTags = false, bool includeGroups = false)
        {
            var query = new UserQuery(0, string.Empty, UserQuerySort.NoSort, false, includeFollowed, includeSubscribedTags, includeGroups);
            var url = this.GetFinalUrl(string.Format("{0}/current.json", Endpoints.Users), query.SerializeQueryString());
            var result = await this.Client.GetAsync<User>(url);

            return result.Content;
        }

        /// <summary>
        /// Suspend a user by his/her id (i.e. soft-delete).
        /// </summary>
        /// <param name="id">The id.</param>
        public async Task SuspendById(long id)
        {
            var url = this.GetFinalUrl(string.Format("{0}/{1}.json", Endpoints.Users, id));

            await this.Client.DeleteAsync(url);
        }

        /// <summary>
        /// Delete a user by his/her id (i.e. hard / permanent deletion).
        /// </summary>
        /// <param name="id">The id.</param>
        public async Task DeleteById(long id)
        {
            var url = this.GetFinalUrl(string.Format("{0}/{1}.json?delete=true", Endpoints.Users, id));

            await this.Client.DeleteAsync(url);
        }
    }

    /// <summary>
    /// The UserClient query helper.
    /// </summary>
    internal class UserQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserQuery"/> class.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="letter">The letter.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="reverse">True to return results in reverse order.</param>
        /// <param name="includeFollowed">True to include followed users.</param>
        /// <param name="includeSubscribedTags">True to include subscribed tags.</param>
        /// <param name="includeGroups">True to include group memberships.</param>
        public UserQuery(
            int page,
            string letter,
            UserQuerySort sort,
            bool reverse,
            bool includeFollowed,
            bool includeSubscribedTags,
            bool includeGroups)
        {
            if (page > 0
                && page != Config.DefaultPageNo)
            {
                this.Page = page;
            }

            if (!string.IsNullOrEmpty(letter))
            {
                this.Letter = letter;
            }

            if (sort != UserQuerySort.NoSort)
            {
                this.Sort_By = sort;
            }

            if (reverse)
            {
                this.Reverse = true;
            }

            if (includeFollowed)
            {
                this.Include_Followed_Users = true;
            }

            if (includeSubscribedTags)
            {
                this.Include_Followed_Tags = true;
            }

            if (includeGroups)
            {
                this.Include_Group_Memberships = true;
            }
        }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <remarks>
        /// Programmatically paginate through the users in the network. 50 users will be shown per page.
        /// </remarks>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the letter.
        /// </summary>
        /// <remarks>
        /// Return users with usernames beginning with the given character.
        /// </remarks>
        public string Letter { get; set; }

        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
        /// <remarks>
        /// Results will be returned sorted by number of messages or followers, instead of the default behavior of sorting alphabetically.
        /// </remarks>
        public UserQuerySort? Sort_By { get; set; }

        /// <summary>
        /// Gets or sets the reverse order.
        /// </summary>
        /// <remarks>
        /// Returns results in reverse order.
        /// </remarks>
        public bool? Reverse { get; set; }

        /// <summary>
        /// Gets or sets the include followed users flag.
        /// </summary>
        /// <remarks>
        /// Returns a list of Yammer users being followed.
        /// </remarks>
        public bool? Include_Followed_Users { get; set; }

        /// <summary>
        /// Gets or sets the include followed tags flag.
        /// </summary>
        /// <remarks>
        /// Returns a list of tags or topics being subscribed to.
        /// </remarks>
        public bool? Include_Followed_Tags { get; set; }

        /// <summary>
        /// Gets or sets the include group memberships flag.
        /// </summary>
        /// <remarks>
        /// Returns a list of group memberships in the current network.
        /// </remarks> 
        public bool? Include_Group_Memberships { get; set; }
    }

    /// <summary>
    /// The user controller query sort order.
    /// </summary>
    public enum UserQuerySort
    {
        /// <summary>
        /// No sorting.
        /// </summary>
        NoSort,

        /// <summary>
        /// Sort by the number of total messages.
        /// </summary>
        Messages,

        /// <summary>
        /// Sort by the number of total followers.
        /// </summary>
        Followers
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Users endpoint.
        /// </summary>
        public const string Users = "/users";
    }
}
