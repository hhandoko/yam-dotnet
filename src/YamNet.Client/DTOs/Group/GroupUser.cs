// -----------------------------------------------------------------------
// <copyright file="GroupUser.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The group users / members.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/04
    /// Sample last retrieved: 2014/04/04
    /// 
    /// GET: https://www.yammer.com/api/v1/users/in_group/{group_id}.json
    /// users: [
    ///     {
    ///         type: "user",
    ///         id: 123456789,
    ///         name: "joebloggs",
    ///         state: "active",
    ///         full_name: "Joe Bloggs",
    ///         job_title: "Employee",
    ///         mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/l0ngrAnDomCh4r5",
    ///         mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/l0ngrAnDomCh4r5",
    ///         url: "https://www.yammer.com/api/v1/users/123456789",
    ///         web_url: "https://www.yammer.com/somenetwork.com/users/joebloggs",
    ///         activated_at: "2013/08/30 09:00:00 +0000",
    ///         stats: {
    ///             following: 10,
    ///             followers: 21,
    ///             updates: 5
    ///         }
    ///     }
    /// ]
    /// </remarks>
    public sealed class GroupUser
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        [JsonProperty("users")]
        public User[] Users { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether more users is available.
        /// Used in paged results.
        /// </summary>
        [JsonProperty("more_available")]
        public bool MoreAvailable { get; set; }
    }
}
