// -----------------------------------------------------------------------
// <copyright file="Participant.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The participant DTO.
    /// </summary>
    public sealed class Participant
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
