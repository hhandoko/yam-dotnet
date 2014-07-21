// -----------------------------------------------------------------------
// <copyright file="TopicBase.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The topic (base) DTO.
    /// </summary>
    public abstract class TopicBase
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

//        /// <summary>
//        /// Gets or sets the references.
//        /// </summary>
//        /// <value>The references.</value>
//        [JsonProperty("references")]
//        [JsonConverter(typeof(ReferenceJsonConverter))]
//        public IReference[] References { get; set; }

        #region System
        /// <summary>
        /// Gets or sets the OG object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the topic id.
        /// </summary>
        [JsonProperty("id")]
        public long TopicId { get; set; }
        #endregion
    }
}
