// -----------------------------------------------------------------------
// <copyright file="GroupMembership.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The group membership DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/24
    /// Sample last retrieved: 2014/04/24
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json?include_group_memberships=true
    /// groups: [
    ///     {
    ///         type: "group",
    ///         id: 12345,
    ///         full_name: "Some Group",
    ///         name: "somegroup",
    ///         description: "A group to discuss anything, really.",
    ///         privacy: "public",
    ///         url: "https://www.yammer.com/api/v1/groups/12345",
    ///         web_url: "https://www.yammer.com/somenetwork.com/#/threads/inGroup?type=in_group&feedId=12345",
    ///         mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/rAnD0MCh4r5-rAnD0MCh4r5",
    ///         mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/rAnD0MCh4r5-rAnD0MCh4r5",
    ///         mugshot_id: "rAnD0MCh4r5-rAnD0MCh4r5",
    ///         office365_url: "https://someguid.sharepoint.com/sites/54321",
    ///         created_at: "2012/23/21 09:00:00 +0000",
    ///         can_invite: true,
    ///         admin: false
    ///     }
    /// ]
    /// </remarks>
    public class GroupMembership : GroupBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the user can invite other users into the group.
        /// </summary>
        [JsonProperty("can_invite")]
        public bool CanInvite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is the group's admin.
        /// </summary>
        [JsonProperty("admin")]
        public bool Admin { get; set; }
    }
}
