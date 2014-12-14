// -----------------------------------------------------------------------
// <copyright file="ConversationReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The conversation reference DTO.
    /// </summary>
    public sealed class ConversationReference
        : IReference
    {
        /// <summary>
        /// The API type value.
        /// </summary>
        public const string ApiType = "conversation";

        /// <summary>
        /// Gets or sets the participants' names.
        /// </summary>
        [JsonProperty("participating_names")]
        public Participant[] Participants { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get { return ApiType; }
        }

        /// <summary>
        /// Gets the reference display value.
        /// </summary>
        [JsonIgnore]
        public string DisplayValue
        {
            get { return string.Empty; }
        }
    }
}
