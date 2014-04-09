// -----------------------------------------------------------------------
// <copyright file="YModule.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The YModule information.
    /// </summary>
    public sealed class YModule
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the inline HTML.
        /// </summary>
        [JsonProperty("inline_html")]
        public string InlineHtml { get; set; }

        /// <summary>
        /// Gets or sets the viewer id.
        /// </summary>
        [JsonProperty("viewer_id")]
        public long ViewerId { get; set; }
    }
}
