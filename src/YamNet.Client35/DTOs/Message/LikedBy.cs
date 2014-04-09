// -----------------------------------------------------------------------
// <copyright file="LikedBy.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The message liked by.
    /// </summary>
    public sealed class LikedBy
    {
        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the names.
        /// </summary>
        [JsonProperty("names")]
        public Like[] Names { get; set; }
    }
}