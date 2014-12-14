// -----------------------------------------------------------------------
// <copyright file="UserGroupTab.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The group home tab.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// home_tabs: [
    ///     {
    ///         name: "Some Group",
    ///         select_name: "Some Group",
    ///         type: "group",
    ///         feed_description: "This feed shows messages in this group.",
    ///         ordering_index: "2",
    ///         url: "https://www.yammer.com/api/v1/messages/in_group/123456",
    ///         group_id: 123456,
    ///         private: false
    ///     }
    /// ]
    /// </remarks>
    public sealed class UserGroupTab
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

        /// <summary>
        /// Gets or sets the group ID.
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the group is private.
        /// </summary>
        [JsonProperty("private")]
        public bool IsPrivate { get; set; }
    }
}
