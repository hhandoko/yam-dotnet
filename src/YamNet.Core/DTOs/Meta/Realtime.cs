// -----------------------------------------------------------------------
// <copyright file="Realtime.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The Realtime API information.
    /// </summary>
    public sealed class Realtime
    {
        /// <summary>
        /// Gets or sets the Realtime API authentication token.
        /// </summary>
        [JsonProperty("authentication_token")]
        public string AuthenticationToken { get; set; }

        /// <summary>
        /// Gets or sets the channel id.
        /// </summary>
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        /// <summary>
        /// Gets or sets the thread channel ids.
        /// </summary>
        [JsonProperty("thread_channel_ids")]
        public string[] ThreadChannelIds { get; set; }

        /// <summary>
        /// Gets or sets the Realtime API url.
        /// </summary>
        [JsonProperty("uri")]
        public Uri Url { get; set; }
    }
}
