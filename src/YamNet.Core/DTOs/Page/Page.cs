// -----------------------------------------------------------------------
// <copyright file="Page.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The page DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/11
    /// Sample last retrieved: 2014/12/11
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=searchquery
    /// pages: [
    ///     {
    ///         id: 123456,
    ///         network_id: 12345,
    ///         url: "https://www.yammer.com/api/v1/notes/12345",
    ///         web_url: "https://www.yammer.com/somenetwork.com/notes/12345",
    ///         preview_url: "https://www.yammer.com/somenetwork.com/notes/12345/preview",
    ///         api_preview_url: "https://www.yammer.com/api/v1/notes/12345/preview",
    ///         type: "page",
    ///         name: "Some query page title",
    ///         full_name: "Some query page title",
    ///         title: "Some query page title",
    ///         group_id: 123456,
    ///         paddie_host: "https://88.docs.yammer.com/",
    ///         paddie_id: "prodpaddie-12345",
    ///         owner_id: 123456789,
    ///         owner_type: "user",
    ///         active: true,
    ///         official: false,
    ///         updated_at: "2014/01/01 04:00:32 +0000",
    ///         last_published_by: 123456789,
    ///         last_published_at: "2014/01/01 03:01:26 +0000",
    ///         latest_revision: 555,
    ///         unpublished_contributor_ids: [ ],
    ///         topics: [ ],
    ///         privacy: "public",
    ///         description: "Some page description",
    ///         latest_version: {
    ///             id: 123456,
    ///             title: "Some query page title",
    ///             created_at: "2014/01/01 03:01:26 +0000",
    ///             web_url: "https://www.yammer.com/somenetwork.com/notes/12345/versions/123456",
    ///             download_url: "https://www.yammer.com/api/v1/notes/12345/versions/123456/download",
    ///             revert_url: null,
    ///             published_by: 12345,
    ///             revision_number: 554,
    ///             contributors: [
    ///                 123456
    ///             ]
    ///         },
    ///         stats: {
    ///             followers: 4
    ///         }
    ///     }         
    /// ]
    /// </remarks>
    public class Page
    {
        #region Details
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        #endregion

        #region Network
        /// <summary>
        /// Gets or sets the home network id.
        /// </summary>
        [JsonProperty("network_id")]
        public long NetworkId { get; set; }
        #endregion

        #region Group
        /// <summary>
        /// Gets or sets the page group id.
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }
        #endregion

        #region Paddie
        /// <summary>
        /// Gets or sets the Paddie host.
        /// </summary>
        [JsonProperty("paddie_host")]
        public Uri PaddieHost { get; set; }

        /// <summary>
        /// Gets or sets the Paddie string ID.
        /// </summary>
        [JsonProperty("paddie_id")]
        public string PaddieId { get; set; }
        #endregion

        #region Owner and Contributors
        /// <summary>
        /// Gets or sets the owner ID.
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the owner OG type.
        /// </summary>
        [JsonProperty("owner_type")]
        public string OwnerType { get; set; }
        #endregion

        #region Visibility
        /// <summary>
        /// Gets or sets a value indicating whether the page is public.
        /// </summary>
        [JsonProperty("privacy")]
        [JsonConverter(typeof(PrivacyJsonConverter))]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the page is active.
        /// </summary>
        [JsonProperty("active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the page is official.
        /// </summary>
        [JsonProperty("official")]
        public bool IsOfficial { get; set; }
        #endregion

        #region Versioning
        /// <summary>
        /// Gets or sets the last update date.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user ID who last published the page.
        /// </summary>
        [JsonProperty("last_published_by")]
        public long? LastPublishedBy { get; set; }

        /// <summary>
        /// Gets or sets the last update date.
        /// </summary>
        [JsonProperty("last_published_at")]
        public DateTimeOffset? LastPublishedAt { get; set; }

        /// <summary>
        /// Gets or sets the latest revision number.
        /// </summary>
        [JsonProperty("latest_revision")]
        public int LatestRevision { get; set; }

        /// <summary>
        /// Gets or sets the latest version information.
        /// </summary>
        [JsonProperty("latest_version")]
        public PageVersion LatestVersion { get; set; }
        #endregion

        #region URL Links
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the web access URL.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
        
        /// <summary>
        /// Gets or sets the preview URL.
        /// </summary>
        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; set; }

        /// <summary>
        /// Gets or sets the API preview URL.
        /// </summary>
        [JsonProperty("api_preview_url")]
        public Uri ApiPreviewUrl { get; set; }
        #endregion

        #region Stats
        /// <summary>
        /// Gets or sets the page statistics.
        /// </summary>
        [JsonProperty("stats")]
        public PageStat Stats { get; set; }
        #endregion

        #region System
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        #endregion
    }
}
