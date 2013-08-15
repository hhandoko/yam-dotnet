// -----------------------------------------------------------------------
// <copyright file="User.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The user.
    /// </summary>
    public sealed class User //: IAutoCompleteValueEx
    {
        #region Account 
        /// <summary>
        /// Gets or sets the guid.
        /// </summary>
        /// <remarks>
        /// Not sure what this property is for.
        /// </remarks>
        [JsonProperty("guid")]
        public Guid? Guid { get; set; }

        /// <summary>
        /// Gets or sets the account activation date + time.
        /// </summary>
        [JsonProperty("activated_at")]
        public DateTimeOffset? ActivatedAt { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the account state / status.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; } //TODO: Map to an enumeration

        /// <summary>
        /// Gets or sets the network domains.
        /// </summary>
        [JsonProperty("network_domains")]
        public string[] NetworkDomains { get; set; }

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
        #endregion

        #region Personal Details
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

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
        /// Gets or sets the full name.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

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
        /// Gets or sets the mugshot url.
        /// </summary>
        [JsonProperty("mugshot_url")]
        public Uri MugshotUrl { get; set; }

        /// <summary>
        /// Gets or sets the mugshot url template.
        /// </summary>
        [JsonProperty("mugshot_url_template")]
        public string MugshotUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the web url.
        /// </summary>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }

        /// <summary>
        /// Gets or sets the contact info.
        /// </summary>
        [JsonProperty("contact")]
        public UserContact ContactInfo { get; set; }
        #endregion

        #region Work, School, and Network
        /// <summary>
        /// Gets or sets the home network id.
        /// </summary>
        [JsonProperty("network_id")]
        public int NetworkId { get; set; }

        /// <summary>
        /// Gets or sets the homenetwork name.
        /// </summary>
        [JsonProperty("network_name")]
        public string NetworkName { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the job title.
        /// </summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

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

        /// <summary>
        /// Gets or sets the group memberships.
        /// </summary>
        [JsonProperty("group_memberships")]
        public Group[] GroupMemberships { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the external urls.
        /// </summary>
        [JsonProperty("external_urls")]
        public string[] ExternalUrls { get; set; } // TODO: Safe to use Uri even though these values are user entered?

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        [JsonProperty("settings")]
        public UserSettings Settings { get; set; }

        /// <summary>
        /// Gets or sets the user statistics.
        /// </summary>
        [JsonProperty("stats")]
        public UserStat Stats { get; set; }

        /// <summary>
        /// Gets or sets the treatments.
        /// </summary>
        [JsonProperty("treatments")]
        public Treatments Treatments { get; set; }
    }
}