// -----------------------------------------------------------------------
// <copyright file="CompanyInfo.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's company / past employment info.
    /// </summary>
    public sealed class CompanyInfo
    {
        /// <summary>
        /// Gets or sets the employment start year.
        /// </summary>
        [JsonProperty("start_year")]
        public int StartYear { get; set; }

        /// <summary>
        /// Gets or sets the employment end year.
        /// </summary>
        [JsonProperty("end_year")]
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        [JsonProperty("position")]
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the position description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the employer / company.
        /// </summary>
        [JsonProperty("employer")]
        public string Employer { get; set; }
    }
}