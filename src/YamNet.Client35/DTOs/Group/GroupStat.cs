// -----------------------------------------------------------------------
// <copyright file="GroupStat.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The group statistics.
    /// </summary>
    public sealed class GroupStat
    {
        /// <summary>
        /// Gets or sets the total number of updates.
        /// </summary>
        [JsonProperty("updates")]
        public int Updates { get; set; }

        /// <summary>
        /// Gets or sets the total number of members.
        /// </summary>
        [JsonProperty("members")]
        public int Members { get; set; }
    }
}
