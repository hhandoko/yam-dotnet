// -----------------------------------------------------------------------
// <copyright file="ReferenceBase.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The reference (base) DTO.
    /// </summary>
    public abstract class ReferenceBase : IReference
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets the display value.
        /// </summary>
        [JsonIgnore]
        public string DisplayValue { get; private set; }
    }
}
