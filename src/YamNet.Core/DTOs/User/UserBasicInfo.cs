// -----------------------------------------------------------------------
// <copyright file="UserBasicInfo.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The user.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14
    /// 
    /// GET: https://www.yammer.com/api/v1/messages.json
    /// references: [
    ///     {
    ///         type: "user",
    ///         id: 123456789,
    ///         name: "joebloggs",
    ///         state: "active",
    ///         full_name: "Joe Bloggs",
    ///         job_title: "Employee",
    ///         network_id: 12345,
    ///         mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/no_photo.png",
    ///         mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/no_photo.png",
    ///         url: "https://www.yammer.com/api/v1/users/123456789",
    ///         web_url: "https://www.yammer.com/somenetwork.com/users/joebloggs",
    ///         activated_at: "2012/01/01 00:21:58 +0000",
    ///         stats: {
    ///             following: 1,
    ///             followers: 1,
    ///             updates: 0
    ///         }
    ///     }
    /// ]
    /// </remarks>
    public class UserBasicInfo
        : IHasId<long>, ITypeInfo, IMugshotLink, IUrlLink
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the object graph type.
        /// </summary>
        // TODO: Map to an enumeration
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the account state / status.
        /// </summary>
        // TODO: Map to an enumeration
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets the home network ID the user belongs to.
        /// </summary>
        [JsonProperty("network_id")]
        public long NetworkId { get; set; }

        #region Mugshot Links
        /// <summary>
        /// Gets or sets the mugshot url.
        /// </summary>
        [JsonProperty("mugshot_url")]
        public Uri MugshotUrl { get; set; }

        /// <summary>
        /// Gets or sets the mugshot url template.
        /// </summary>
        [JsonProperty("mugshot_url_template")]
        public string MugshotUrlTemplate { get; set; }
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
        #endregion

        /// <summary>
        /// Gets or sets the account activation date + time.
        /// </summary>
        [JsonProperty("activated_at")]
        public DateTimeOffset? ActivatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user statistics.
        /// </summary>
        [JsonProperty("stats")]
        public UserStat Stats { get; set; }
    }
}