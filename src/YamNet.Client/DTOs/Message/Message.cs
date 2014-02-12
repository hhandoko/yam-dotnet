// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The message DTO.
    /// </summary>
    public sealed class Message
    {
        #region System
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the thread id.
        /// </summary>
        /// <value>The thread id.</value>
        [JsonProperty("thread_id")]
        public long ThreadId { get; set; }

        /// <summary>
        /// Gets or sets the replied to id.
        /// </summary>
        /// <value>The replied to id.</value>
        [JsonProperty("replied_to_id")]
        public long? RepliedToId { get; set; }

        /// <summary>
        /// Gets or sets the group id.
        /// </summary>
        /// <value>The group id.</value>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        [JsonProperty("message_type")]
        public string MessageType { get; set; }

        /// <summary>
        /// Gets or sets the is system message.
        /// </summary>
        /// <value>The is system message.</value>
        [JsonProperty("system_message")]
        public bool IsSystemMessage { get; set; }

        /// <summary>
        /// Gets or sets the sender id.
        /// </summary>
        /// <value>The sender id.</value>
        [JsonProperty("sender_id")]
        public long SenderId { get; set; }

        /// <summary>
        /// Gets or sets the type of the sender.
        /// </summary>
        /// <value>The type of the sender.</value>
        [JsonProperty("sender_type")]
        public string SenderType { get; set; }

        /// <summary>
        /// Gets or sets the network id.
        /// </summary>
        /// <value>The network id.</value>
        [JsonProperty("network_id")]
        public long NetworkId { get; set; }

        /// <summary>
        /// Gets or sets the web URL.
        /// </summary>
        /// <value>The web URL.</value>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [JsonProperty("body")]
        public MessageBody MessageBody { get; set; }

        /// <summary>
        /// Gets or sets the client URL.
        /// </summary>
        /// <value>The client URL.</value>
        [JsonProperty("client_url")]
        public Uri ClientUrl { get; set; }

        /// <summary>
        /// Gets or sets the is public.
        /// </summary>
        /// <value>The is public.</value>
        [JsonProperty("privacy")]
        [JsonConverter(typeof(PrivacyJsonConverter))]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the type of the client.
        /// </summary>
        /// <value>The type of the client.</value>
        [JsonProperty("client_type")]
        public string ClientType { get; set; }

        /// <summary>
        /// Gets or sets the is direct message.
        /// </summary>
        /// <value>The is direct message.</value>
        [JsonProperty("direct_message")]
        public bool IsDirectMessage { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
//        [JsonProperty("attachments")]
//        [JsonConverter(typeof(AttachmentJsonConverter))]
//        public IAttachment[] Attachments { get; set; }

        /// <summary>
        /// Gets or sets the liked by.
        /// </summary>
        /// <value>The liked by.</value>
        [JsonProperty("liked_by")]
        public LikedBy LikedBy { get; set; }

//        [JsonProperty("title")]
//        public string Title { get; set; }
    }
}