// -----------------------------------------------------------------------
// <copyright file="UserEmailAddress.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user email address.
    /// </summary>
    public sealed class UserEmailAddress
    {
        /// <summary>
        /// Gets or sets the email address type (e.g. primary).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}