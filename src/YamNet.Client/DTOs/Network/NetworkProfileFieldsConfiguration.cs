// -----------------------------------------------------------------------
// <copyright file="NetworkProfileFieldConfiguration.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The network profile field configuration DTO.
    /// </summary>
    public sealed class NetworkProfileFieldsConfiguration
    {
        /// <summary>
        /// Gets or sets the enable job title display option.
        /// </summary>
        [JsonProperty("enable_job_title")]
        public bool EnableJobTitle { get; set; }

        /// <summary>
        /// Gets or sets the enable work phone display option.
        /// </summary>
        [JsonProperty("enable_work_phone")]
        public bool EnableWorkPhone { get; set; }

        /// <summary>
        /// Gets or sets the enable mobile phone display option.
        /// </summary>
        [JsonProperty("enable_mobile_phone")]
        public bool EnableMobilePhone { get; set; }
    }
}
