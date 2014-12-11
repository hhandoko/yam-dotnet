// -----------------------------------------------------------------------
// <copyright file="MessageBasicInfo.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The message DTO.
    /// </summary>
    public class MessageBasicInfo
        : MessageBase
    {
        #region System
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
        /// Gets or sets the message body.
        /// </summary>
        /// <value>The body.</value>
        [JsonProperty("body")]
        public MessageBody MessageBody { get; set; }
    }
}