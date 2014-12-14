// -----------------------------------------------------------------------
// <copyright file="Topic.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The message topic.
    /// </summary>
    /// <remarks> 
    /// DTO last checked     : 2014/04/24
    /// Sample last retrieved: 2014/04/24
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=something
    /// topics: [
    ///     {
    ///         type: "topic",
    ///         id: 12345,
    ///         name: "Some Topic",
    ///         normalized_name: "some topic",
    ///         permalink: "some topic",
    ///         url: "https://www.yammer.com/api/v1/topics/12345",
    ///         web_url: "https://www.yammer.com/somenetwork.com/topics/12345",
    ///         references: [],
    ///         expert_referents: []
    ///     }
    /// ]
    /// </remarks>
    public class Topic : TopicBasicInfo
    {
        /// <summary>
        /// Gets or sets the references.
        /// </summary>
        /// <value>The references.</value>
        [JsonProperty("references")]
        [JsonConverter(typeof(ReferenceJsonConverter))]
        public IReference[] References { get; set; }
    }
}
