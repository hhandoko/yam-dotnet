// -----------------------------------------------------------------------
// <copyright file="UserIm.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user instant messaging (IM) contact details.
    /// </summary>
    public sealed class UserIm
    {
        /// <summary>
        /// Gets or sets the IM provider.
        /// </summary>
        [JsonProperty("provider")]
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the IM username.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}