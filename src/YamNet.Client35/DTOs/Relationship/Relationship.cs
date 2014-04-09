// -----------------------------------------------------------------------
// <copyright file="Relationship.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user relationship DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/04
    /// Sample last retrieved: 2014/04/04
    /// 
    /// GET: https://www.yammer.com/api/v1/relationships.json
    /// {
    ///     subordinates: [ ],
    ///     superiors: [
    ///         {
    ///             type: "user",
    ///             id: 234567891,
    ///             name: "somemanager",
    ///             state: "active",
    ///             full_name: "Some Manager",
    ///             job_title: "Manager",
    ///             mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/no_photo.png",
    ///             mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/no_photo.png",
    ///             url: "https://www.yammer.com/api/v1/users/234567891",
    ///             web_url: "https://www.yammer.com/somenetwork.com/users/somemanager",
    ///             activated_at: "2012/05/18 06:00:00 +0000",
    ///             stats: {
    ///                 following: 15,
    ///                 followers: 12,
    ///                 updates: 1
    ///             }
    ///         }
    ///     ],
    ///     colleagues: [ ]
    /// }
    /// </remarks>
    public sealed class Relationship
    {
        /// <summary>
        /// Gets or sets the user's superiors.
        /// </summary>
        [JsonProperty("superiors")]
        public User[] Superiors { get; set; }

        /// <summary>
        /// Gets or sets the user's colleagues.
        /// </summary>
        [JsonProperty("colleagues")]
        public User[] Colleagues { get; set; }

        /// <summary>
        /// Gets or sets the user's subordinates.
        /// </summary>
        [JsonProperty("subordinates")]
        public User[] Subordinates { get; set; }
    }
}
