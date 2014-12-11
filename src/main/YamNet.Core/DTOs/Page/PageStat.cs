// -----------------------------------------------------------------------
// <copyright file="PageStat.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The page statistics DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/11
    /// Sample last retrieved: 2014/12/11
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=searchquery
    /// stats: {
    ///     followers: 4
    /// }
    /// </remarks>
    public class PageStat
    {
        /// <summary>
        /// Gets or sets the total followers count.
        /// </summary>
        [JsonProperty("followers")]
        public int Followers { get; set; }
    }
}
