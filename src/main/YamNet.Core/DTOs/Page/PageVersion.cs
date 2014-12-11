// -----------------------------------------------------------------------
// <copyright file="PageVersion.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The page version DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/11
    /// Sample last retrieved: 2014/12/11
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=searchquery
    /// latest_version: {
    ///     id: 123456,
    ///     title: "Some query page title",
    ///     created_at: "2014/01/01 03:01:26 +0000",
    ///     web_url: "https://www.yammer.com/somenetwork.com/notes/12345/versions/123456",
    ///     download_url: "https://www.yammer.com/api/v1/notes/12345/versions/123456/download",
    ///     revert_url: null,
    ///     published_by: 12345,
    ///     revision_number: 554,
    ///     contributors: [
    ///         123456
    ///     ]
    /// }
    /// </remarks>
    public class PageVersion
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the page creation date + time.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets the web access URL.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the download URL.
        /// </summary>
        [JsonProperty("download_url")]
        public Uri DownloadUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the revert URL.
        /// </summary>
        [JsonProperty("revert_url")]
        public string RevertUrl { get; set; }

        /// <summary>
        /// Gets or sets the user ID who published the page.
        /// </summary>
        [JsonProperty("published_by")]
        public long PublishedBy { get; set; }

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        [JsonProperty("revision")]
        public int Revision { get; set; }

        /// <summary>
        /// Gets or sets the contributor IDs.
        /// </summary>
        [JsonProperty("contributors")]
        public long[] Contributors { get; set; }
    }
}
