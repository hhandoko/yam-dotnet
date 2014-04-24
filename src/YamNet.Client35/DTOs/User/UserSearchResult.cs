// -----------------------------------------------------------------------
// <copyright file="User.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The user search result DTO.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/04/24
    /// Sample last retrieved: 2014/04/24
    /// 
    /// GET: https://www.yammer.com/api/v1/search.json?search=hello
    /// users: [
    ///     {
    ///         type: "user",
    ///         id: 123456789,
    ///         network_id: 12345,
    ///         state: "active",
    ///         guid: null,
    ///         job_title: "Employee",
    ///         location: "Perth, WA, Australia",
    ///         significant_other: "",
    ///         kids_names: "",
    ///         interests: "Software development",
    ///         summary: "My work history can go here :)",
    ///         expertise: "Yammer Certified Power User",
    ///         full_name: "Joe Bloggs",
    ///         activated_at: "2012/03/15 00:00:00 +0000",
    ///         show_ask_for_photo: false,
    ///         first_name: "Joe",
    ///         last_name: "Bloggs",
    ///         network_name: "Some Network",
    ///         network_domains: [
    ///             "somenetwork.com",
    ///             "alternativenetwork.com",
    ///             "sm.com",
    ///         ],
    ///         url: "https://www.yammer.com/api/v1/users/123456789",
    ///         web_url: "https://www.yammer.com/somenetwork.com/users/joebloggs",
    ///         name: "joebloggs",
    ///         mugshot_url: "https://mug0.assets-yammer.com/mugshot/images/48x48/l0ngr4nDomCh4r5",
    ///         mugshot_url_template: "https://mug0.assets-yammer.com/mugshot/images/{width}x{height}/l0ngr4nDomCh4r5",
    ///         hire_date: null,
    ///         birth_date: "",
    ///         timezone: "Perth",
    ///         external_urls: [
    ///             "http://au.linkedin.com/in/joe.bloggs",
    ///             "http://joebloggs.com",
    ///             "http://facebook.com/joe.bloggs"
    ///         ],
    ///         admin: "false",
    ///         verified_admin: "false",
    ///         can_broadcast: "false",
    ///         department: "Some Department",
    ///         previous_companies: [
    ///             {
    ///                  employer: "Old Company",
    ///                  position: "Developer",
    ///                  description: "",
    ///                  start_year: 2006,
    ///                  end_year: 2008
    ///              }
    ///         ],
    ///         schools: [
    ///             {
    ///                 school: "Some College",
    ///                 degree: "Diploma of Commerce",
    ///                 description: "",
    ///                 start_year: 2000,
    ///                 end_year: 2001
    ///             }
    ///         ],
    ///         contact: {
    ///             im: {
    ///                 provider: "aim",
    ///                 username: ""
    ///             },
    ///             phone_numbers: [
    ///                 {
    ///                     type: "work",
    ///                     number: "+61898765432 x432"
    ///                 },
    ///                 {
    ///                     type: "mobile",
    ///                     number: "+61401234567"
    ///                 }
    ///             ],
    ///             email_addresses: [
    ///                 {
    ///                     type: "primary",
    ///                     address: "joe.bloggs@somenetwork.com"
    ///                 }
    ///             ],
    ///             has_fake_email: false
    ///         },
    ///         stats: {
    ///             following: 8,
    ///             followers: 30,
    ///             updates: 263
    ///         },
    ///         settings: {
    ///             xdr_proxy: "https://xdrproxy.yammer.com"
    ///         }
    ///     }
    /// ]
    /// </remarks>
    public sealed class UserSearchResult : UserBasicInfo
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
        public int NetworkId { get; set; }

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

        #region Options / Configuration
        /// <summary>
        /// Gets or sets a value indicating whether prompt should be displayed asking to update photo.
        /// </summary>
        [JsonProperty("show_ask_for_photo")]
        public bool ShowAskForPhoto { get; set; }

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
    }
}