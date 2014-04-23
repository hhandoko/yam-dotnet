// -----------------------------------------------------------------------
// <copyright file="SearchEnvelope.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// Search API response that contains a list of messages, a list of users, 
    /// a list of topics and a list of groups that match the search query.
    /// </summary>
    public sealed class SearchEnvelope
    {
        /// <summary>
        /// Gets or sets the topcis.
        /// </summary>
        [JsonProperty("topics")]
        public TopicSearchResult[] Topics { get; set; }
    }
}
