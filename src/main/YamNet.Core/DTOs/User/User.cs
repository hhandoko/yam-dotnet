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
    /// DTO last checked     : 2014/03/04
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
    ///     previous_companies: [
    ///         {
    ///              employer: "Old Company",
    ///              position: "Developer",
    ///              description: "",
    ///              start_year: 2006,
    ///              end_year: 2008
    ///          }
    ///     ],
    ///     schools: [
    ///         {
    ///             school: "Some College",
    ///             degree: "Diploma of Commerce",
    ///             description: "",
    ///             start_year: 2000,
    ///             end_year: 2001
    ///         }
    ///     ],
    ///     contact: {
    ///         im: {
    ///             provider: "aim",
    ///             username: ""
    ///         },
    ///         phone_numbers: [
    ///             {
    ///                 type: "work",
    ///                 number: "+61898765432 x432"
    ///             },
    ///             {
    ///                 type: "mobile",
    ///                 number: "+61401234567"
    ///             }
    ///         ],
    ///         email_addresses: [
    ///             {
    ///                 type: "primary",
    ///                 address: "joe.bloggs@somenetwork.com"
    ///             }
    ///         ],
    ///         has_fake_email: false
    ///     },
    ///     stats: {
    ///         following: 8,
    ///         followers: 30,
    ///         updates: 263
    ///     },
    ///     settings: {
    ///         xdr_proxy: "https://xdrproxy.yammer.com"
    ///     },
    ///     web_preferences: {
    ///         show_full_names: "true",
    ///         absolute_timestamps: "false",
    ///         threaded_mode: "true",
    ///         network_settings: {
    ///               message_prompt: "Check out the Guidelines and join Help me Yammer for help.",
    ///               allow_attachments: "true",
    ///               show_communities_directory: true,
    ///               enable_groups: true,
    ///               allow_yammer_apps: true,
    ///               admin_can_delete_messages: "true",
    ///               allow_inline_document_view: false,
    ///               allow_inline_video: true,
    ///               enable_private_messages: true,
    ///               allow_external_sharing: true,
    ///               enable_chat: true
    ///         },
    ///         home_tabs: [
    ///             {
    ///                 name: "My Feed",
    ///                 select_name: "My Feed",
    ///                 type: "following",
    ///                 feed_description: "This feed shows messages from members you follow and groups you join.",
    ///                 ordering_index: "1",
    ///                 url: "https://www.yammer.com/api/v1/messages/following"
    ///             },
    ///             {
    ///                 name: "Company Feed",
    ///                 select_name: "Company Feed",
    ///                 type: "all",
    ///                 feed_description: "This feed shows messages from everyone in your company, excluding private messages.",
    ///                 ordering_index: "2",
    ///                 url: "https://www.yammer.com/api/v1/messages"
    ///             },
    ///             {
    ///                 name: "Private Messages",
    ///                 select_name: "Private Messages",
    ///                 type: "private",
    ///                 feed_description: "This feed shows private messages you've sent or received.",
    ///                 ordering_index: "3",
    ///                 url: "https://www.yammer.com/api/v1/messages/private"
    ///             },
    ///             {
    ///                 name: "Inbox",
    ///                 select_name: "Inbox",
    ///                 type: "inbox",
    ///                 feed_description: "Inbox contains all conversations that directly apply to you.",
    ///                 ordering_index: "4",
    ///                 url: "https://www.yammer.com/api/v1/messages/inbox"
    ///             },
    ///             {
    ///                 name: "Bookmarks",
    ///                 select_name: "Bookmarks",
    ///                 type: "bookmark",
    ///                 feed_description: "This feed shows messages you've bookmarked.",
    ///                 ordering_index: "5",
    ///                 url: "https://www.yammer.com/api/v1/messages/bookmarked_by"
    ///             },
    ///             {
    ///                 name: "Likes",
    ///                 select_name: "Likes",
    ///                 type: "like",
    ///                 feed_description: "This feed shows messages you've liked.",
    ///                 ordering_index: "6",
    ///                 url: "https://www.yammer.com/api/v1/messages/liked_by"
    ///             },
    ///             {
    ///                 name: "Sent Messages",
    ///                 select_name: "Sent Messages",
    ///                 type: "sent",
    ///                 feed_description: "This feed shows messages you've sent.",
    ///                 ordering_index: "7",
    ///                 url: "https://www.yammer.com/api/v1/messages/sent"
    ///             },
    ///             {
    ///                 name: "RSS",
    ///                 select_name: "RSS",
    ///                 type: "followed_bots",
    ///                 feed_description: "<span class="translation_missing" title="translation missing: en-US.home_section.rss_description">Rss Description</span>",
    ///                 ordering_index: "8",
    ///                 url: "https://www.yammer.com/api/v1/messages/followed_bots"
    ///             },
    ///             {
    ///                 name: "Some Group",
    ///                 select_name: "Some Group",
    ///                 type: "group",
    ///                 feed_description: "This feed shows messages in this group.",
    ///                 ordering_index: "9",
    ///                 url: "https://www.yammer.com/api/v1/messages/in_group/12345",
    ///                 group_id: 12345,
    ///                 private: false
    ///              },
    ///         ],
    ///         enter_does_not_submit_message: "true",
    ///         preferred_my_feed: "algo",
    ///         prescribed_my_feed: "algo",
    ///         sticky_my_feed: false,
    ///         enable_chat: "true",
    ///         dismissed_feed_tooltip: false,
    ///         dismissed_group_tooltip: false,
    ///         dismissed_profile_prompt: false,
    ///         dismissed_invite_tooltip: true,
    ///         dismissed_apps_tooltip: true,
    ///         dismissed_invite_tooltip_at: "2012/10/08 05:21:38 +0000",
    ///         locale: "en-US"
    ///     },
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
    public sealed class User : UserBasicInfo
    {
        #region Details
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the significant other's name.
        /// </summary>
        [JsonProperty("significant_other")]
        public string SignificantOtherName { get; set; }

        /// <summary>
        /// Gets or sets the kids' names.
        /// </summary>
        [JsonProperty("kids_names")]
        public string KidsNames { get; set; }

        /// <summary>
        /// Gets or sets the user's interests.
        /// </summary>
        [JsonProperty("interests")]
        public string Interests { get; set; }

        /// <summary>
        /// Gets or sets the contact info.
        /// </summary>
        [JsonProperty("contact")]
        public UserContact ContactInfo { get; set; }

        /// <summary>
        /// Gets or sets the external urls.
        /// </summary>
        [JsonProperty("external_urls")]
        public string[] ExternalUrls { get; set; } // TODO: Safe to use Uri even though these values are user entered?
        #endregion

        #region Work and Education
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the expertise.
        /// </summary>
        [JsonProperty("expertise")]
        public string Expertise { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the timezone.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; } //TODO: Convert to TimeZoneInfo

        /// <summary>
        /// Gets or sets the previous companies.
        /// </summary>
        [JsonProperty("previous_companies")]
        public CompanyInfo[] PreviousCompanies { get; set; }

        /// <summary>
        /// Gets or sets the schools.
        /// </summary>
        [JsonProperty("schools")]
        public SchoolInfo[] Schools { get; set; }
        #endregion

        #region Network
        /// <summary>
        /// Gets or sets the home network id.
        /// </summary>
        [JsonProperty("network_id")]
        public long NetworkId { get; set; }

        /// <summary>
        /// Gets or sets the home network name.
        /// </summary>
        [JsonProperty("network_name")]
        public string NetworkName { get; set; }

        /// <summary>
        /// Gets or sets the network domains.
        /// </summary>
        [JsonProperty("network_domains")]
        public string[] NetworkDomains { get; set; }

        /// <summary>
        /// Gets or sets the canonical network name.
        /// </summary>
        [JsonProperty("canonical_network_name")]
        public string CanonicalNetworkName { get; set; }
        #endregion

        #region Groups
        /// <summary>
        /// Gets or sets the group memberships.
        /// </summary>
        [JsonProperty("group_memberships")]
        public GroupMembership[] GroupMemberships { get; set; }
        #endregion

        #region Graph
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

        #region Options / Configuration
        /// <summary>
        /// Gets or sets a value indicating whether prompt should be displayed asking to update photo.
        /// </summary>
        [JsonProperty("show_ask_for_photo")]
        public bool ShowAskForPhoto { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to follow general messages.
        /// </summary>
        [JsonProperty("follow_general_messages")]
        public bool FollowGeneralMessages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is an admin.
        /// </summary>
        [JsonProperty("admin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is a verified admin.
        /// </summary>
        [JsonProperty("verified_admin")]
        public bool IsVerifiedAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user can broadcast in the network.
        /// </summary>
        [JsonProperty("can_broadcast")]
        public bool CanBroadcast { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        [JsonProperty("settings")]
        public UserSettings Settings { get; set; }

        /// <summary>
        /// Gets or sets the web preferences.
        /// </summary>
        [JsonProperty("web_preferences")]
        public UserWebPreferences WebPreferences { get; set; }
        #endregion

        #region System
        /// <summary>
        /// Gets or sets the guid.
        /// </summary>
        /// <remarks>
        /// Not sure what this property is for.
        /// </remarks>
        [JsonProperty("guid")]
        public Guid? Guid { get; set; }
        #endregion

        #region Miscellaneous
        /// <summary>
        /// Gets or sets the treatments.
        /// </summary>
        [JsonProperty("treatments")]
        public Treatments Treatments { get; set; }

        /// <summary>
        /// Gets or sets the web OAuth access token.
        /// </summary>
        [JsonProperty("web_oauth_access_token")]
        public string WebOAuthAccessToken { get; set; }
        #endregion
    }
}