// -----------------------------------------------------------------------
// <copyright file="SchoolInfo.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's school / education info.
    /// </summary>
    public sealed class SchoolInfo
    {
        /// <summary>
        /// Gets or sets the education start year.
        /// </summary>
        [JsonProperty("start_year")]
        public int StartYear { get; set; }

        /// <summary>
        /// Gets or sets the education end year.
        /// </summary>
        [JsonProperty("end_year")]
        public int EndYear { get; set; }

        /// <summary>
        /// Gets or sets the degree attained.
        /// </summary>
        [JsonProperty("degree")]
        public string Degree { get; set; }

        /// <summary>
        /// Gets or sets the school / education institution.
        /// </summary>
        [JsonProperty("school")]
        public string School { get; set; }

        /// <summary>
        /// Gets or sets the education description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}