// -----------------------------------------------------------------------
// <copyright file="GroupBase.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The group (base) DTO.
    /// </summary>
    public abstract class GroupBase
    {
        #region Details
        /// <summary>
        /// Gets or sets the permalink name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        #endregion

        #region Options / Configuration
        // TODO: Deprecated? 2014/04/24
        /// <summary>
        /// Gets or sets the value indicating whether the group is public.
        /// </summary>
        [JsonProperty("privacy")]
        [JsonConverter(typeof(PrivacyJsonConverter))]
        public bool IsPublic { get; set; }

        // TODO: Deprecated? 2014/04/04
        /// <summary>
        /// Gets or sets the value indicating whether the group should be shown in the group directory.
        /// </summary>
        [JsonProperty("show_in_directory")]
        public bool ShowInDirectory { get; set; }
        #endregion

        #region Mugshot
        /// <summary>
        /// Gets or sets the mugshot id.
        /// </summary>
        [JsonProperty("mugshot_id")]
        public string MugshotId { get; set; }

        /// <summary>
        /// Gets or sets the mugshot URL.
        /// </summary>
        [JsonProperty("mugshot_url")]
        public Uri MugshotUrl { get; set; }

        /// <summary>
        /// Gets or sets the mugshot URL template.
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
        /// Gets or sets the web URL.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the Office 365 web URL.
        /// </summary>
        [JsonProperty("office365_url")]
        public Uri Office365Url { get; set; }
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

        /// <summary>
        /// Gets or sets the created at date time.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        #endregion
    }
}
