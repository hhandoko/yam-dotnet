// -----------------------------------------------------------------------
// <copyright file="TopicBase.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The topic (base) DTO.
    /// </summary>
    public class TopicBase
    {
        #region System
        /// <summary>
        /// Gets or sets the OG object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the topic id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
        #endregion
    }
}
