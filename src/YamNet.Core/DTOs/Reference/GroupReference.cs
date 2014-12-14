// -----------------------------------------------------------------------
// <copyright file="GroupReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The group reference DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/10
    /// Sample last retrieved: 2014/12/10
    /// 
    /// GET: https://www.yammer.com/api/v1/messages.json
    /// references: [
    ///     {
    ///         type: "group",
    ///         id: 12345,
    ///         full_name: "Some Group",
    ///         name: "somegroup",
    ///         description: "Some group.",
    ///         privacy: "public",
    ///         url: "https://www.yammer.com/api/v1/groups/12345",
    ///         web_url: "https://www.yammer.com/somenetwork.com/#/threads/inGroup?type=in_group&feedId=12345",
    ///         mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/group_profile.png",
    ///         mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/group_profile.png",
    ///         mugshot_id: "",
    ///         office365_url: "https://someguid.sharepoint.com/sites/12345",
    ///         created_at: "2012/01/01 03:11:08 +0000"
    ///     }
    /// ]
    /// </remarks>
    public sealed class GroupReference
        : GroupBase, IReference
    {
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
