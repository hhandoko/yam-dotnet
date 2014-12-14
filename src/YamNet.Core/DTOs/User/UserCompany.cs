// -----------------------------------------------------------------------
// <copyright file="UserCompany.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user's company / past employment info.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json
    /// previous_companies: [
    ///     {
    ///         employer: "Past Company Ltd.",
    ///         position: "Past Position",
    ///         description: "Past position description",
    ///         start_year: 2001,
    ///         end_year: 2005
    ///     }
    /// ]
    /// </remarks>
    public sealed class UserCompany
    {
        /// <summary>
        /// Gets or sets the employer / company.
        /// </summary>
        [JsonProperty("employer")]
        public string Employer { get; set; }

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
        /// Gets or sets the employment start year.
        /// </summary>
        [JsonProperty("start_year")]
        public int StartYear { get; set; }

        /// <summary>
        /// Gets or sets the employment end year.
        /// </summary>
        [JsonProperty("end_year")]
        public int EndYear { get; set; }
    }
}