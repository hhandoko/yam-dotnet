// -----------------------------------------------------------------------
// <copyright file="SearchCount.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// Search results count.
    /// </summary>
    public sealed class SearchCount
    {
        /// <summary>
        /// Gets or sets the messages search result count.
        /// </summary>
        [JsonProperty("messages")]
        public int Messages { get; set; }

        /// <summary>
        /// Gets or sets the groups search result count.
        /// </summary>
        [JsonProperty("groups")]
        public int Groups { get; set; }

        /// <summary>
        /// Gets or sets the topics search result count.
        /// </summary>
        [JsonProperty("topics")]
        public int Topics { get; set; }

        /// <summary>
        /// Gets or sets the uploaded files search result count.
        /// </summary>
        [JsonProperty("uploaded_files")]
        public int UploadedFiles { get; set; }

        /// <summary>
        /// Gets or sets the users search result count.
        /// </summary>
        [JsonProperty("users")]
        public int Users { get; set; }

        /// <summary>
        /// Gets or sets the pages search result count.
        /// </summary>
        [JsonProperty("pages")]
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets the events search result count.
        /// </summary>
        [JsonProperty("events")]
        public int Events { get; set; }

        /// <summary>
        /// Gets or sets the polls search result count.
        /// </summary>
        [JsonProperty("polls")]
        public int Polls { get; set; }

        /// <summary>
        /// Gets or sets the praises search result count.
        /// </summary>
        [JsonProperty("praises")]
        public int Praises { get; set; }
    }
}
