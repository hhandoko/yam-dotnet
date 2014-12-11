// -----------------------------------------------------------------------
// <copyright file="MessageReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The message reference DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/10
    /// Sample last retrieved: 2014/12/10
    /// 
    /// GET: https://www.yammer.com/api/v1/messages.json
    /// references: [
    ///     {
    ///         type: "message",
    ///         url: "https://www.yammer.com/api/v1/messages/123456789",
    ///         web_url: "https://www.yammer.com/example.com/messages/123456789",
    ///         id: 123456789,
    ///         sender_id: 123456788,
    ///         replied_to_id: null,
    ///         created_at: "2014/01/01 02:41:15 +0000",
    ///         network_id: 12345,
    ///         sender_type: "user",
    ///         thread_id: 1234567,
    ///         message_type: "system",
    ///         system_message: true,
    ///         content_excerpt: "Hello, world!",
    ///         language: "en",
    ///         privacy: "public",
    ///         direct_message: false,
    ///         body: {
    ///             plain: "Hello, world!"
    ///         }
    ///     }
    /// ]
    /// </remarks>
    public sealed class MessageReference
        : MessageBasicInfo, IReference
    {
        /// <summary>
        /// The API type value.
        /// </summary>
        public const string ApiType = "message";

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
