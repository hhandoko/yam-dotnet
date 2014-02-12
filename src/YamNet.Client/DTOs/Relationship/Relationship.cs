// -----------------------------------------------------------------------
// <copyright file="Relationship.cs" company="YamNet">
//   Copyright (c) YamNet 2014 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user relationship DTO.
    /// </summary>
    public sealed class Relationship
    {
        /// <summary>
        /// Gets or sets the user's superiors.
        /// </summary>
        [JsonProperty("superiors")]
        public User[] Superiors { get; set; }

        /// <summary>
        /// Gets or sets the user's colleagues.
        /// </summary>
        [JsonProperty("colleagues")]
        public User[] Colleagues { get; set; }

        /// <summary>
        /// Gets or sets the user's subordinates.
        /// </summary>
        [JsonProperty("subordinates")]
        public User[] Subordinates { get; set; }
    }
}
