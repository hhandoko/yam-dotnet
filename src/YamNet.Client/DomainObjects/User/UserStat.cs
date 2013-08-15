// -----------------------------------------------------------------------
// <copyright file="UserStat.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user statistics.
    /// </summary>
    public sealed class UserStat
    {
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

        /// <summary>
        /// Gets or sets the number of followed users.
        /// </summary>
        [JsonProperty("following")]
        public int Following { get; set; }
    }
}

