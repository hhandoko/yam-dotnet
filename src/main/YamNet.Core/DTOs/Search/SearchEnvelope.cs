// -----------------------------------------------------------------------
// <copyright file="SearchEnvelope.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// Search API response that contains a list of messages, a list of users, 
    /// a list of topics and a list of groups that match the search query.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/24
    /// Sample last retrieved: 2014/04/24
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=something
    /// {
    ///     count: {...},
    ///     messages: {...},
    ///     groups: {...},
    ///     topics: {...},
    ///     uploaded_files: {...},
    ///     users: {...},
    ///     pages: {...},
    ///     search_uuid: "s0m3L0ng-Gu1d-tH4t-isUn-1quEF0rSuR31"
    /// }
    /// </remarks>
    public sealed class SearchEnvelope
    {
        // TODO: Add 'uploaded_files' objects

        /// <summary>
        /// Gets or sets the search results count.
        /// </summary>
        [JsonProperty("count")]
        public SearchCount Count { get; set; }

        /// <summary>
        /// Gets or sets the message search results.
        /// </summary>
        [JsonProperty("messages")]
        public MessageEnvelope Messages { get; set; }

        /// <summary>
        /// Gets or sets the group search results.
        /// </summary>
        [JsonProperty("groups")]
        public GroupSearchResult[] Groups { get; set; }

        /// <summary>
        /// Gets or sets the topic search results.
        /// </summary>
        [JsonProperty("topics")]
        public TopicSearchResult[] Topics { get; set; }

        /// <summary>
        /// Gets or sets the user search results.
        /// </summary>
        [JsonProperty("users")]
        public UserSearchResult[] Users { get; set; }

        /// <summary>
        /// Gets or sets the pages search results.
        /// </summary>
        [JsonProperty("pages")]
        public Page[] Pages { get; set; }

        /// <summary>
        /// Gets or sets the search UUID / GUID.
        /// </summary>
        [JsonProperty("search_uuid")]
        public Guid SearchUuid { get; set; }
    }
}
