// -----------------------------------------------------------------------
// <copyright file="UserSettings.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user settings.
    /// </summary>
    public sealed class UserSettings
    {
        /// <summary>
        /// Gets or sets the cross-domain redirect (XDR) proxy.
        /// </summary>
        [JsonProperty("xdr_proxy")]
        public string XdrProxy { get; set; }
    }
}