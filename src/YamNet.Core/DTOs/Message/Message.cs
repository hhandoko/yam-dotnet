// -----------------------------------------------------------------------
// <copyright file="Message.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// The message DTO.
    /// </summary>
    public sealed class Message
        : MessageBasicInfo
    {
        /// <summary>
        /// Gets or sets the group id.
        /// </summary>
        /// <value>The group id.</value>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// Gets or sets the client URL.
        /// </summary>
        /// <value>The client URL.</value>
        [JsonProperty("client_url")]
        public Uri ClientUrl { get; set; }

        /// <summary>
        /// Gets or sets the type of the client.
        /// </summary>
        /// <value>The type of the client.</value>
        [JsonProperty("client_type")]
        public string ClientType { get; set; }

        /// <summary>
        /// Gets or sets the group created id
        /// </summary>
        [JsonProperty("group_created_id")]
        public long? GroupCreatedId { get; set; }

        /// <summary>
        /// Gets or sets the liked by.
        /// </summary>
        /// <value>The liked by.</value>
        [JsonProperty("liked_by")]
        public LikedBy LikedBy { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        //        [JsonProperty("attachments")]
        //        [JsonConverter(typeof(AttachmentJsonConverter))]
        //        public IAttachment[] Attachments { get; set; }

        //        [JsonProperty("title")]
        //        public string Title { get; set; }
    }
}