// -----------------------------------------------------------------------
// <copyright file="Like.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The like.
    /// </summary>
    public sealed class Like
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the user's full name.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the user permalink (i.e. username).
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }
    }
}
