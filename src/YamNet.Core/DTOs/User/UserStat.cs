// -----------------------------------------------------------------------
// <copyright file="UserStat.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's statistics.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// stats: {
    ///     following: 14,
    ///     followers: 40,
    ///     updates: 263
    /// }
    /// </remarks>
    public sealed class UserStat
    {
        /// <summary>
        /// Gets or sets the number of followed users.
        /// </summary>
        [JsonProperty("following")]
        public int Following { get; set; }

        /// <summary>
        /// Gets or sets the number of followers.
        /// </summary>
        [JsonProperty("followers")]
        public int Followers { get; set; }

        /// <summary>
        /// Gets or sets the number of updates.
        /// </summary>
        [JsonProperty("updates")]
        public int Updates { get; set; }
    }
}

