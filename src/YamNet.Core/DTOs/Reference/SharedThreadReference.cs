// -----------------------------------------------------------------------
// <copyright file="SharedThreadReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The shared thread reference DTO.
    /// </summary>
    public sealed class SharedThreadReference
        : ThreadReference
    {
        /// <summary>
        /// Gets the API object type.
        /// </summary>
        [JsonProperty("type")]
        public new string Type
        {
            get { return "shared_thread"; }
        }

        /// <summary>
        /// Gets the reference display name.
        /// </summary>
        [JsonIgnore]
        public string DisplayName
        {
            get { return "Shared Thread"; }
        }
    }
}