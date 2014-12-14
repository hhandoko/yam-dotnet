// -----------------------------------------------------------------------
// <copyright file="UserSchool.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's school / education info.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// schools: [
    ///     {
    ///         school: "Some College",
    ///         degree: "Some Diploma",
    ///         description: "Some description",
    ///         start_year: 2000,
    ///         end_year: 2001
    ///     }
    /// ]
    /// </remarks>
    public sealed class UserSchool
    {
        /// <summary>
        /// Gets or sets the school / education institution.
        /// </summary>
        [JsonProperty("school")]
        public string School { get; set; }

        /// <summary>
        /// Gets or sets the degree attained.
        /// </summary>
        [JsonProperty("degree")]
        public string Degree { get; set; }

        /// <summary>
        /// Gets or sets the education description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

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
    }
}