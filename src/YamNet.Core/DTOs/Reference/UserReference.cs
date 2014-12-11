// -----------------------------------------------------------------------
// <copyright file="UserReference.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user reference DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/10
    /// Sample last retrieved: 2014/12/10
    /// 
    /// GET: https://www.yammer.com/api/v1/messages.json
    /// references: [
    ///     {
    ///         type: "user",
    ///         id: 123456789,
    ///         name: "joebloggs",
    ///         state: "active",
    ///         full_name: "Joe Bloggs",
    ///         job_title: "Employee",
    ///         network_id: 12345,
    ///         mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/no_photo.png",
    ///         mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/no_photo.png",
    ///         url: "https://www.yammer.com/api/v1/users/123456789",
    ///         web_url: "https://www.yammer.com/example.com/users/joebloggs",
    ///         activated_at: "2012/01/01 00:21:58 +0000",
    ///         stats: {
    ///             following: 1,
    ///             followers: 1,
    ///             updates: 0
    ///         }
    ///     }
    /// ]
    /// </remarks>
    public sealed class UserReference
        : UserBasicInfo, IReference
    {
        /// <summary>
        /// The supported API types.
        /// </summary>
        public static readonly string[] ApiTypes = { "user", "bot", "guide" };
        
        /// <summary>
        /// Gets the reference display value.
        /// </summary>
        [JsonIgnore]
        public string DisplayValue
        {
            get { return this.FullName; }
        }
    }
}
