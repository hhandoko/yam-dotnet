// -----------------------------------------------------------------------
// <copyright file="MessageBase.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The base message DTO.
    /// </summary>
    public class MessageBase
    {
        /// <summary>
        /// Gets or sets the value indicating whether this is a direct message.
        /// </summary>
        /// <value>The is direct message.</value>
        [JsonProperty("direct_message")]
        public bool IsDirectMessage { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the message is public.
        /// </summary>
        /// <value>The is public.</value>
        [JsonProperty("privacy")]
        [JsonConverter(typeof(PrivacyJsonConverter))]
        public bool IsPublic { get; set; }

        #region URL links
        /// <summary>
        /// Gets or sets the web URL.
        /// </summary>
        /// <value>The web URL.</value>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        public Uri Url { get; set; }
        #endregion

        #region System
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public long Id { get; set; }
        #endregion
    }
}
