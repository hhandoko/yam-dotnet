// -----------------------------------------------------------------------
// <copyright file="UserSettings.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's settings.
    /// </summary>
    public sealed class UserSettings
    {
        /// <summary>
        /// Gets or sets the cross-domain redirect (XDR) proxy.
        /// </summary>
        /// <remarks>
        /// DTO last checked     : 2014/12/14
        /// Sample last retrieved: 2014/12/14 
        /// 
        /// GET: https://www.yammer.com/api/v1/users/current.json
        /// settings: {
        ///     xdr_proxy: "https://xdrproxy.yammer.com"
        /// }
        /// </remarks>
        [JsonProperty("xdr_proxy")]
        public string XdrProxy { get; set; }
    }
}