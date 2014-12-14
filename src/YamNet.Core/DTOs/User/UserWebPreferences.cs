// -----------------------------------------------------------------------
// <copyright file="UserWebPreferences.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The user's web preferences.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// web_preferences: {
    ///     absolute_timestamps: "false",
    ///     threaded_mode: "true",
    ///     network_settings: { ... },
    ///     home_tabs: [{ ... }, { ... }],
    ///     enter_does_not_submit_message: "true",
    ///     preferred_my_feed: "algo",
    ///     prescribed_my_feed: "algo",
    ///     sticky_my_feed: false,
    ///     enable_chat: "true",
    ///     dismissed_feed_tooltip: false,
    ///     dismissed_group_tooltip: false,
    ///     dismissed_profile_prompt: false,
    ///     dismissed_invite_tooltip: true,
    ///     dismissed_apps_tooltip: true,
    ///     dismissed_invite_tooltip_at: "2012/01/01 05:21:38 +0000",
    ///     dismissed_browser_lifecycle_banner: null,
    ///     make_yammer_homepage: true,
    ///     locale: "en-GB-AU",
    ///     yammer_now_app_id: 12345,
    ///     has_yammer_now: false,
    ///     has_mobile_client: true
    /// }
    /// </remarks>
    public sealed class UserWebPreferences
    {
        /// <summary>
        /// Gets or sets a value indicating whether absolute timestamps is in use.
        /// </summary>
        [JsonProperty("absolute_timestamps")]
        public bool IsAbsoluteTimestamps { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether message threaded mode is active.
        /// </summary>
        [JsonProperty("threaded_mode")]
        public bool IsThreadedMode { get; set; }

        /// <summary>
        /// Gets or sets the user's Yammer network settings.
        /// </summary>
        [JsonProperty("network_settings")]
        public UserNetworkSettings NetworkSettings { get; set; }

        /// <summary>
        /// Gets or sets the home tabs.
        /// </summary>
        [JsonProperty("home_tabs")]
        [JsonConverter(typeof(HomeTabConverter))]
        public IHomeTab[] HomeTabs { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Enter key press will submit message.
        /// </summary>
        [JsonProperty("enter_does_not_submit_message")]
        public bool EnterDoesNotSubmitMessage { get; set; }

        /// <summary>
        /// Gets or sets the preferred My Feed algo.
        /// </summary>
        [JsonProperty("preferred_my_feed")]
        public string PreferredMyFeed { get; set; }

        /// <summary>
        /// Gets or sets the presribed My Feed algo.
        /// </summary>
        [JsonProperty("prescribed_my_feed")]
        public string PrescribedMyFeed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether My Feed has been set to sticky.
        /// </summary>
        [JsonProperty("sticky_my_feed")]
        public bool IsStickyMyFeed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether chat feature is enabled.
        /// </summary>
        [JsonProperty("enable_chat")]
        public bool IsChatEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether feed tooltip has been dismissed.
        /// </summary>
        [JsonProperty("dismissed_feed_tooltip")]
        public bool IsFeedTooltipDismissed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether group tooltip has been dismissed.
        /// </summary>
        [JsonProperty("dismissed_group_tooltip")]
        public bool IsGroupTooltipDismissed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether profile prompt has been dismissed.
        /// </summary>
        [JsonProperty("dismissed_profile_prompt")]
        public bool IsProfilePromptDismissed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether invitation tooltip has been dismissed.
        /// </summary>
        [JsonProperty("dismissed_invite_tooltip")]
        public bool IsInviteTooltipDismissed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether apps tooltip has been dismissed.
        /// </summary>
        [JsonProperty("dismissed_apps_tooltip")]
        public bool IsAppsTooltipDismissed { get; set; }

        /// <summary>
        /// Gets or sets the date and time invite tooltip was dismissed.
        /// </summary>
        [JsonProperty("dismissed_invite_tooltip_at")]
        public DateTimeOffset InviteTooltipDismissedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether legacy browser warning banner is shown.
        /// </summary>
        [JsonProperty("dismissed_browser_lifecycle_banner")]
        public bool? IsBrowserLifecycleBannerDismissed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating Yammer set as the homepage.
        /// </summary>
        [JsonProperty("make_yammer_homepage")]
        public bool IsMakeYammerHomepage { get; set; }

        /// <summary>
        /// Gets or sets the current user's locale.
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or set the Yammer Now app ID.
        /// </summary>
        [JsonProperty("yammer_now_app_id")]
        public long YammerNowAppId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has installed Yammer Now app.
        /// </summary>
        [JsonProperty("has_yammer_now")]
        public bool HasYammerNow { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has installed the mobile client.
        /// </summary>
        [JsonProperty("has_mobile_client")]
        public bool HasMobileClient { get; set; }
    }
}