// -----------------------------------------------------------------------
// <copyright file="Group.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The group membership DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/04
    /// Sample last retrieved: 2014/04/04
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json?include_group_memberships=true
    /// {
    ///     type: "group",
    ///     id: 12345,
    ///     full_name: "Some Group",
    ///     name: "somegroup",
    ///     description: "A group to discuss anything, really.",
    ///     privacy: "public",
    ///     url: "https://www.yammer.com/api/v1/groups/12345",
    ///     web_url: "https://www.yammer.com/somenetwork.com/#/threads/inGroup?type=in_group&feedId=12345",
    ///     mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/rAnD0MCh4r5-rAnD0MCh4r5",
    ///     mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/rAnD0MCh4r5-rAnD0MCh4r5",
    ///     mugshot_id: "rAnD0MCh4r5-rAnD0MCh4r5",
    ///     office365_url: "https://someguid.sharepoint.com/sites/54321",
    ///     created_at: "2012/23/21 09:00:00 +0000",
    ///     can_invite: true,
    ///     admin: false
    /// }
    /// </remarks>
    public sealed class Group
    {
        #region Details
        /// <summary>
        /// Gets or sets the name / permalink.
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

        // TODO: Deprecated? 2014/04/04
        /// <summary>
        /// Gets or sets the creator id.
        /// </summary>
        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        // TODO: Deprecated? 2014/04/04
        /// <summary>
        /// Gets or sets the type of the creator.
        /// </summary>
        [JsonProperty("creator_type")]
        public string CreatorType { get; set; }

        // TODO: Deprecated? 2014/04/04
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        // TODO: Deprecated? 2014/04/04
        /// <summary>
        /// Gets or sets the group statistics.
        /// </summary>
        [JsonProperty("stats")]
        public GroupStat Stats { get; set; }
        #endregion
    }
}
