// -----------------------------------------------------------------------
// <copyright file="NetworkGroupCount.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// The network group count DTO.
    /// </summary>
    public sealed class NetworkGroupCount
    {
        /// <summary>
        /// Gets or sets the unseen general thread count.
        /// </summary>
        [JsonProperty("unseen_general_thread_count")]
        public int UnseenGeneralThreadCount { get; set; }

        /// <summary>
        /// Gets or sets the unseen group thread counts.
        /// </summary>
        [JsonProperty("unseen_group_thread_counts")]
        public Dictionary<long, int> UnseenGroupThreadCounts { get; set; }
    }
}
