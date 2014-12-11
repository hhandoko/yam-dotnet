// -----------------------------------------------------------------------
// <copyright file="GroupSearchResult.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The group search result DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/24
    /// Sample last retrieved: 2014/04/24
    /// Used in              : SearchEnvelope
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=something
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
    ///         creator_type: "user",
    ///         creator_id: 12345,
    ///         state: "active",
    ///         stats: {
    ///             members: 18,
    ///             updates: 0,
    ///             last_message_id: 987654321,
    ///             last_message_at: "2012/12/21 12:12:20 +0000"
    ///         }
    ///     }
    /// ]
    /// </remarks>
    public sealed class GroupSearchResult : GroupBase
    {
        /// <summary>
        /// Gets or sets the creator id.
        /// </summary>
        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the type of the creator.
        /// </summary>
        [JsonProperty("creator_type")]
        public string CreatorType { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the group statistics.
        /// </summary>
        [JsonProperty("stats")]
        public GroupStat Stats { get; set; }
    }
}
