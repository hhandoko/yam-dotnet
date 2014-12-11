// -----------------------------------------------------------------------
// <copyright file="MessageEnvelope.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// Notification stream response.
    /// </summary>
    public sealed class NotificationEnvelope
    {
        // TODO: Add `items` object
        // TODO: Add `external_references` object
        // TODO: Add `objects` object

        /// <summary>
        /// Gets or sets the references.
        /// </summary>
        /// <value>The references.</value>
        [JsonProperty("references")]
        [JsonConverter(typeof(ReferenceJsonConverter))]
        public IReference[] References { get; set; }

        /// <summary>
        /// Gets or sets the meta.
        /// </summary>
        /// <value>The meta.</value>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
