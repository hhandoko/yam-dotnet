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
    public sealed class GroupUser
    {
        /// <summary>
        /// Gets or sets the previous companies.
        /// </summary>
        [JsonProperty("users")]
        public User[] Users { get; set; }

        [JsonProperty("more_available")]
        public bool MoreAvailable { get; set; }

        // TODO: Get GroupUser Meta
    }
}
