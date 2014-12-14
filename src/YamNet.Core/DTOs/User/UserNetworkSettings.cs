// -----------------------------------------------------------------------
// <copyright file="UserNetworkSettings.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's network settings.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// network_settings: {
    ///     message_prompt: "Share something here... See the guidelines for help. ",
    ///     allow_attachments: "true",
    ///     show_communities_directory: false,
    ///     enable_groups: true,
    ///     allow_yammer_apps: true,
    ///     admin_can_delete_messages: "true",
    ///     allow_inline_document_view: false,
    ///     allow_inline_video: true,
    ///     enable_private_messages: true,
    ///     allow_external_sharing: true,
    ///     enable_chat: true
    /// }
    /// </remarks>
    public sealed class UserNetworkSettings
    {
        /// <summary>
        /// Gets or sets the new entry message prompt.
        /// </summary>
        [JsonProperty("message_prompt")]
        public string MessagePrompt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether attachment is allowed.
        /// </summary>
        [JsonProperty("allow_attachments")]
        public bool IsAttachmentAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether communities directory is shown.
        /// </summary>
        [JsonProperty("show_communities_directory")]
        public bool IsCommunitiesDirectoryShown { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether groups is enabled.
        /// </summary>
        [JsonProperty("enable_groups")]
        public bool IsGroupEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Yammer apps is allowed.
        /// </summary>
        [JsonProperty("allow_yammer_apps")]
        public bool IsYammerAppsAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether admin can delete messages.
        /// </summary>
        [JsonProperty("admin_can_delete_messages")]
        public bool CanAdminDeleteMessages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether inline document view is allowed.
        /// </summary>
        [JsonProperty("allow_inline_document_view")]
        public bool IsInlineDocumentViewAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether inline video is allowed.
        /// </summary>
        [JsonProperty("allow_inline_video")]
        public bool IsInlineVideoAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether private messages is allowed.
        /// </summary>
        [JsonProperty("enable_private_messages")]
        public bool IsPrivateMessagesAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether external sharing is allowed.
        /// </summary>
        [JsonProperty("allow_external_sharing")]
        public bool IsExternalSharingAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether chat is enabled.
        /// </summary>
        [JsonProperty("enable_chat")]
        public bool IsChatEnabled { get; set; }
    }
}
