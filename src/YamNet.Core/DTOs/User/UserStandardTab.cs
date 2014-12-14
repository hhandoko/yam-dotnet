// -----------------------------------------------------------------------
// <copyright file="UserStandardTab.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The standard home tab.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// home_tabs: [
    ///     {
    ///         name: "My Feed",
    ///         select_name: "My Feed",
    ///         type: "following",
    ///         feed_description: "This feed shows messages from members you follow and groups you join.",
    ///         ordering_index: "1",
    ///         url: "https://www.yammer.com/api/v1/messages/following"
    ///     }
    /// ]
    /// </remarks>
    public sealed class UserStandardTab
        : IHomeTab
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the selected name.
        /// </summary>
        [JsonProperty("select_name")]
        public string SelectName { get; set; }

        /// <summary>
        /// Gets or sets the tab type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the feed description.
        /// </summary>
        [JsonProperty("feed_description")]
        public string FeedDescription { get; set; }

        /// <summary>
        /// Gets or sets the ordering index.
        /// </summary>
        [JsonProperty("ordering_index")]
        public string OrderingIndex { get; set; }

        /// <summary>
        /// Gets or sets the tab API URL.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
