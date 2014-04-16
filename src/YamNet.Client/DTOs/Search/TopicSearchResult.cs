namespace YamNet.Client
{
    using System;
    using Newtonsoft.Json;

    public sealed class TopicSearchResult
    {

        [JsonProperty("id")]
        public long TopicId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("normalized_name")]
        public string NormalizedName { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

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

    }
}
