// -----------------------------------------------------------------------
// <copyright file="UserPhoneNumber.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user phone number.
    /// </summary>
    public sealed class UserPhoneNumber
    {
        /// <summary>
        /// Gets or sets the phone number type (e.g. work).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}