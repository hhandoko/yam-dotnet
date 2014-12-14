// -----------------------------------------------------------------------
// <copyright file="TagReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The tag reference DTO.
    /// </summary>
    public sealed class TagReference : IReference
    {
        /// <summary>
        /// The API value type.
        /// </summary>
        public const string ApiType = "tag";
        
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        #region URL Links
        /// <summary>
        /// Gets or sets the API URL.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the web URL.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
        #endregion

        #region System
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets the API object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get { return ApiType; }
        }
        #endregion

        /// <summary>
        /// Gets the reference display value.
        /// </summary>
        [JsonIgnore]
        public string DisplayValue
        {
            get { return this.Name; }
        }
    }
}
