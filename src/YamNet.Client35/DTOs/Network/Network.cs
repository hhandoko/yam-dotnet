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
    /// The user's network DTO.
    /// </summary>
    /// <remarks> 
    /// DTO last checked     : 2014/04/03
    /// Sample last retrieved: 2014/04/03
    /// 
    /// GET: https://www.yammer.com/api/v1/networks/current.json
    /// {
    ///     type: "network",
    ///     id: 12345,
    ///     name: "Some Network",
    ///     community: false,
    ///     permalink: "somenetwork.com",
    ///     web_url: "https://www.yammer.com/somenetwork.com",
    ///     show_upgrade_banner: false,
    ///     header_background_color: "#E60D2E",
    ///     header_text_color: "#FFFFFF",
    ///     navigation_background_color: "#38699F",
    ///     navigation_text_color: "#FFFFFF",
    ///     paid: true,
    ///     moderated: false,
    ///     is_org_chart_enabled: true,
    ///     is_group_enabled: true,
    ///     is_chat_enabled: true,
    ///     is_translation_enabled: true,
    ///     created_at: "2001/03/04 18:00:00 +0000",
    ///     profile_fields_config: {
    ///         enable_job_title: true,
    ///         enable_work_phone: true,
    ///         enable_mobile_phone: true
    ///     },
    ///     unseen_message_count: 12,
    ///     preferred_unseen_message_count: 12,
    ///     private_unseen_thread_count: 0,
    ///     inbox_unseen_thread_count: 0,
    ///     is_primary: true,
    ///     unseen_notification_count: 0
    /// }
    /// </remarks>
    public sealed class Network
    {
        #region Details
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the permalink.
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }
        #endregion

        #region URL Links
        /// <summary>
        /// Gets or sets the network web url.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
        #endregion

        #region Notifications and Messages
        /// <summary>
        /// Gets or sets the number of unseen inbox threads.
        /// </summary>
        [JsonProperty("inbox_unseen_thread_count")]
        public int? InboxUnseenThreadCount { get; set; }

        /// <summary>
        /// Gets or sets the number of unseen private thread updates.
        /// </summary>
        [JsonProperty("private_unseen_thread_count")]
        public int? PrivateUnseenThreadCount { get; set; }

        /// <summary>
        /// Gets or sets the number of unseen preferred messages.
        /// </summary>
        [JsonProperty("preferred_unseen_message_count")]
        public int? PreferredUnseenMessagesCount { get; set; }

        /// <summary>
        /// Gets or sets the number of unseen messages.
        /// </summary>
        [JsonProperty("unseen_messages_count")]
        public int? UnseenMessagesCount { get; set; }

        /// <summary>
        /// Gets or sets the number of unseen notifications / alerts.
        /// </summary>
        [JsonProperty("unseen_notification_count")]
        public int? UnseenNotificationCount { get; set; }

        // TODO: Deprecated? 2014/03/04
        /// <summary>
        /// Gets or sets the network group count.
        /// </summary>
        [JsonProperty("group_counts")]
        public NetworkGroupCount GroupCounts { get; set; }
        #endregion

        #region Display Properties
        /// <summary>
        /// Gets or sets the header text colour.
        /// </summary>
        [JsonProperty("header_text_color")]
        public string HeaderTextColor { get; set; }

        /// <summary>
        /// Gets or sets the header background colour.
        /// </summary>
        [JsonProperty("header_background_color")]
        public string HeaderBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the navigation text colour.
        /// </summary>
        [JsonProperty("navigation_text_color")]
        public string NavigationTextColor { get; set; }

        /// <summary>
        /// Gets or sets the navigation background colour.
        /// </summary>
        [JsonProperty("navigation_background_color")]
        public string NavigationBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the network profile fields configuration.
        /// </summary>
        [JsonProperty("profile_fields_config")]
        public NetworkProfileFieldsConfiguration ProfileFieldsConfig { get; set; }
        #endregion

        #region Options / Configuration
        /// <summary>
        /// Gets or sets a value indicating whether chat feature is enabled.
        /// </summary>
        [JsonProperty("is_chat_enabled")]
        public bool IsChatEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether groups feature is enabled.
        /// </summary>
        [JsonProperty("is_group_enabled")]
        public bool IsGroupEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether organisational chart feature is enabled.
        /// </summary>
        [JsonProperty("is_org_chart_enabled")]
        public bool IsOrgChartEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the translation feature is enabled.
        /// </summary>
        [JsonProperty("is_translation_enabled")]
        public bool IsTranslationEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if upgrade banner should be shown.
        /// </summary>
        [JsonProperty("show_upgrade_banner")]
        public bool ShowUpgradeBanner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a paid network.
        /// </summary>
        [JsonProperty("paid")]
        public bool IsPaid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating a moderated network.
        /// </summary>
        [JsonProperty("moderated")]
        public bool IsModerated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the network is a community network.
        /// </summary>
        [JsonProperty("community")]
        public bool IsCommunity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this network is the user's primary network.
        /// </summary>
        [JsonProperty("is_primary")]
        public bool IsPrimary { get; set; }
        #endregion

        #region System
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        #endregion
    }
}
