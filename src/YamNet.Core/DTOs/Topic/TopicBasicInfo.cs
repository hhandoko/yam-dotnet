// -----------------------------------------------------------------------
// <copyright file="TopicBasicInfo.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The topic DTO with only basic info.
    /// </summary>
    public class TopicBasicInfo : TopicBase
    {
        #region Details
        /// <summary>
        /// Gets or sets the topic name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the topic normalized name.
        /// </summary>
        [JsonProperty("normalized_name")]
        public string NormalizedName { get; set; }

        /// <summary>
        /// Gets or sets the topic permalink.
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }
        #endregion

        #region URL links
        /// <summary>
        /// Gets or sets the topic web URL.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the topic API URL.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }
        #endregion
    }
}
