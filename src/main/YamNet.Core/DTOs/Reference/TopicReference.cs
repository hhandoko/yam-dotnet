// -----------------------------------------------------------------------
// <copyright file="TopicReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The topic reference DTO.
    /// </summary>
    public sealed class TopicReference
        : TopicBasicInfo, IReference
    {
        /// <summary>
        /// The API type value.
        /// </summary>
        public const string ApiType = "topic";

        /// <summary>
        /// Gets the type object.
        /// </summary>
        [JsonProperty("type")]
        public new string Type
        {
            get { return ApiType; }
        }

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
