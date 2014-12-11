// -----------------------------------------------------------------------
// <copyright file="ThreadStats.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The thread statistics DTO.
    /// </summary>
    public class ThreadStats
    {
        /// <summary>
        /// Gets or sets the first reply id.
        /// </summary>
        [JsonProperty("first_reply_id")]
        public long? FirstReplyId { get; set; }

        /// <summary>
        /// Gets or sets the first reply timestamp.
        /// </summary>
        [JsonProperty("first_reply_at")]
        public DateTimeOffset? FirstReplyAt { get; set; }

        /// <summary>
        /// Gets or sets the latest reply id.
        /// </summary>
        [JsonProperty("latest_reply_id")]
        public long? LatestReplyId { get; set; }

        /// <summary>
        /// Gets or sets the latest reply timestamp.
        /// </summary>
        [JsonProperty("latest_reply_at")]
        public DateTimeOffset? LatestReplyAt { get; set; }

        /// <summary>
        /// Gets or sets the total number of updates.
        /// </summary>
        [JsonProperty("updates")]
        public int Updates { get; set; }

        /// <summary>
        /// Gets or sets the total number of shares.
        /// </summary>
        [JsonProperty("shares")]
        public int Shares { get; set; }
    }
}
