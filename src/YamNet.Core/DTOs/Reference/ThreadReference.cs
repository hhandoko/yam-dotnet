// -----------------------------------------------------------------------
// <copyright file="ThreadReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The thread reference DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/10
    /// Sample last retrieved: 2014/12/10
    /// 
    /// GET: https://www.yammer.com/api/v1/messages.json
    /// references: [
    ///     {
    ///         url: "https://www.yammer.com/api/v1/messages/in_thread/123456789",
    ///         web_url: "https://www.yammer.com/somenetwork.com/threads/123456789",
    ///         type: "thread",
    ///         id: 123456789,
    ///         network_id: 12345,
    ///         thread_starter_id: 123456789,
    ///         group_id: null,
    ///         topics: [
    ///             {
    ///                 id: 123456,
    ///                 type: "topic"
    ///             }
    ///         ],
    ///         privacy: "public",
    ///         direct_message: false,
    ///         has_attachments: false,
    ///         stats: {
    ///             updates: 1,
    ///             shares: 0,
    ///             first_reply_id: null,
    ///             first_reply_at: null,
    ///             latest_reply_id: 123456789,
    ///             latest_reply_at: "2014/01/01 00:59:50 +0000"
    ///         },
    ///         invited_user_ids: [ ]
    ///     }
    /// ]
    /// </remarks>
    public class ThreadReference
        : MessageBase, IReference
    {
        //TODO: invited_user_ids object

        /// <summary>
        /// The API type value.
        /// </summary>
        public const string ApiType = "thread";

        /// <summary>
        /// Gets or sets the thread starter id.
        /// </summary>
        [JsonProperty("thread_starter_id")]
        public long ThreadStarterId { get; set; }

        /// <summary>
        /// Gets or sets the group id.
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether attachment exists.
        /// </summary>
        [JsonProperty("has_attachments")]
        public bool HasAttachments { get; set; }

        /// <summary>
        /// Gets or sets the thread topics.
        /// </summary>
        [JsonProperty("topics")]
        public TopicBase[] Topics { get; set; }

        /// <summary>
        /// Gets or sets the thread statistics.
        /// </summary>
        [JsonProperty("stats")]
        public ThreadStats Stats { get; set; }

        /// <summary>
        /// Gets the API type.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get { return ApiType; }
        }

        /// <summary>
        /// Gets the reference display value.
        /// </summary>
        [JsonIgnore]
        public string DisplayValue
        {
            get { return string.Empty; }
        }
    }
}
