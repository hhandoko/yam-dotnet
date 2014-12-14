// -----------------------------------------------------------------------
// <copyright file="User.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// The user DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/04/04
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json?include_group_memberships=true&include_followed_tags=true&include_followed_users=true
    /// {
    ///     type: "user",
    ///     id: 123456789,
    ///     network_id: 12345,
    ///     state: "active",
    ///     guid: null,
    ///     job_title: "Employee",
    ///     location: "Perth, WA, Australia",
    ///     significant_other: "",
    ///     kids_names: "",
    ///     interests: "Software development",
    ///     summary: "My work history can go here :)",
    ///     expertise: "Yammer Certified Power User",
    ///     full_name: "Joe Bloggs",
    ///     activated_at: "2012/03/15 00:00:00 +0000",
    ///     show_ask_for_photo: false,
    ///     first_name: "Joe",
    ///     last_name: "Bloggs",
    ///     network_name: "Some Network",
    ///     network_domains: [
    ///         "somenetwork.com",
    ///         "alternativenetwork.com",
    ///         "sm.com",
    ///     ],
    ///     url: "https://www.yammer.com/api/v1/users/123456789",
    ///     web_url: "https://www.yammer.com/somenetwork.com/users/joebloggs",
    ///     name: "joebloggs",
    ///     mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/l0ngr4nDomCh4r5",
    ///     mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/l0ngr4nDomCh4r5",
    ///     hire_date: null,
    ///     birth_date: "",
    ///     timezone: "Perth",
    ///     external_urls: [
    ///         "http://au.linkedin.com/in/joe.bloggs",
    ///         "http://joebloggs.com",
    ///         "http://facebook.com/joe.bloggs"
    ///     ],
    ///     admin: "false",
    ///     verified_admin: "false",
    ///     can_broadcast: "false",
    ///     department: "Some Department",
    ///     previous_companies: [{ ... }, { ... }],
    ///     schools: [{ ... }, { ... }],
    ///     contact: { ... },
    ///     stats: { ... },
    ///     settings: { ... },
    ///     web_preferences: { ... },
    ///     follow_general_messages: false,
    ///     group_memberships: [
    ///         {
    ///             type: "group",
    ///             id: 12345,
    ///             full_name: "Some Group",
    ///             name: "somegroup",
    ///             description: "A group to discuss anything, really.",
    ///             privacy: "public",
    ///             url: "https://www.yammer.com/api/v1/groups/12345",
    ///             web_url: "https://www.yammer.com/somenetwork.com/#/threads/inGroup?type=in_group&feedId=12345",
    ///             mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/rAnD0MCh4r5-rAnD0MCh4r5",
    ///             mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/rAnD0MCh4r5-rAnD0MCh4r5",
    ///             mugshot_id: "rAnD0MCh4r5-rAnD0MCh4r5",
    ///             office365_url: "https://someguid.sharepoint.com/sites/54321",
    ///             created_at: "2012/23/21 09:00:00 +0000",
    ///             can_invite: true,
    ///             admin: false
    ///         }
    ///     ],
    ///     pending_group_memberships: [ ],
    ///     subscriptions: [
    ///         {
    ///             type: "user",
    ///             id: 345678912,
    ///             name: "janebloggs",
    ///             state: "active",
    ///             full_name: "Jane Bloggs",
    ///             job_title: "Employee",
    ///             mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/no_photo.png",
    ///             mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/no_photo.png",
    ///             url: "https://www.yammer.com/api/v1/users/345678912",
    ///             web_url: "https://www.yammer.com/somenetwork.com/users/janebloggs",
    ///             activated_at: "2012/03/12 06:00:00 +0000",
    ///             stats: {
    ///                 following: 9,
    ///                 followers: 7,
    ///                 updates: 5
    ///             }
    ///         }
    ///     ],
    ///     web_oauth_access_token: "rAnDomCh4r5"
    /// }
    /// </remarks>
    public sealed class UserFullInfo : User
    {
        /// <summary>
        /// Gets or sets the web preferences.
        /// </summary>
        [JsonProperty("web_preferences")]
        public UserWebPreferences WebPreferences { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to follow general messages.
        /// </summary>
        [JsonProperty("follow_general_messages")]
        public bool FollowGeneralMessages { get; set; }

        /// <summary>
        /// Gets or sets the group memberships.
        /// </summary>
        [JsonProperty("group_memberships")]
        public GroupMembership[] GroupMemberships { get; set; }

        #region Subscription Graph
        /// <summary>
        /// Gets or sets the user's subscription (e.g. followed tags, followed users).
        /// </summary>
        [JsonProperty("subscriptions")]
        internal UserBasicInfo[] Subscription { get; set; }

        /// <summary>
        /// Gets the followed users.
        /// </summary>
        public UserBasicInfo[] FollowedUsers
        {
            get { return this.Subscription.Where(x => x.Type == "user").ToArray(); }
        }
        #endregion

        /// <summary>
        /// Gets or sets the web OAuth access token.
        /// </summary>
        [JsonProperty("web_oauth_access_token")]
        public string WebOAuthAccessToken { get; set; }

        /// <summary>
        /// Gets or sets the treatments.
        /// </summary>
        [JsonProperty("treatments")]
        public Treatments Treatments { get; set; }
    }
}