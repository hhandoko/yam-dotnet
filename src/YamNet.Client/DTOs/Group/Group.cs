// -----------------------------------------------------------------------
// <copyright file="Group.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The group DTO.
    /// </summary>
    public sealed class Group //: IAutoCompleteValueEx
    {
        /// <summary>
        /// Gets or sets the created at date time.
        /// </summary>
        /// <value>The created at.</value>
        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the creator id.
        /// </summary>
        /// <value>The creator id.</value>
        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the type of the creator.
        /// </summary>
        /// <value>The type of the creator.</value>
        [JsonProperty("creator_type")]
        public string CreatorType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the mugshot id.
        /// </summary>
        /// <value>The mugshot id.</value>
        [JsonProperty("mugshot_id")]
        public string MugshotId { get; set; }

        /// <summary>
        /// Gets or sets the mugshot URL.
        /// </summary>
        /// <value>The mugshot URL.</value>
        [JsonProperty("mugshot_url")]
        public Uri MugshotUrl { get; set; }

        /// <summary>
        /// Gets or sets the mugshot URL template.
        /// </summary>
        /// <value>The mugshot URL template.</value>
        [JsonProperty("mugshot_url_template")]
        public string MugshotUrlTemplate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the is public.
        /// </summary>
        /// <value>The is public.</value>
        [JsonProperty("privacy")]
        [JsonConverter(typeof(PrivacyJsonConverter))]
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the show in directory.
        /// </summary>
        /// <value>The show in directory.</value>
        [JsonProperty("show_in_directory")]
        public bool ShowInDirectory { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the stats.
        /// </summary>
        /// <value>The stats.</value>
        [JsonProperty("stats")]
        public GroupStat Stats { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the web URL.
        /// </summary>
        /// <value>The web URL.</value>
        [JsonProperty("web_url")]
        public Uri WebUrl { get; set; }
    }
}
