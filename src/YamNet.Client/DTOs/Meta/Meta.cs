// -----------------------------------------------------------------------
// <copyright file="Meta.cs" company="YamNet">
//   Copyright (c) YamNet 2014 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The response meta-information.
    /// </summary>
    public sealed class Meta
    {
        /// <summary>
        /// Gets or sets the bookmarked message ids.
        /// </summary>
        [JsonProperty("bookmarked_message_ids")]
        public long[] BookmarkedMessageIds { get; set; }

        /// <summary>
        /// Gets or sets the current user id.
        /// </summary>
        [JsonProperty("current_user_id")]
        public long CurrentUserId { get; set; }

        /// <summary>
        /// Gets or sets the featured feed token.
        /// </summary>
        [JsonProperty("featured_feed_token")]
        public string FeaturedFeedToken { get; set; }

        /// <summary>
        /// Gets or sets the feed name.
        /// </summary>
        [JsonProperty("feed_name")]
        public string FeedName { get; set; }

        /// <summary>
        /// Gets or sets the feed description.
        /// </summary>
        [JsonProperty("feed_desc")]
        public string FeedDescription { get; set; }

        //[JsonProperty( "followed_references" )]
        //public FollowedReference[] FollowedReferences { get; set; }

        /// <summary>
        /// Gets or sets the followed user ids.
        /// </summary>
        [JsonProperty("followed_user_ids")]
        public long[] FollowedUserIds { get; set; }

        /// <summary>
        /// Gets or sets the is direct from body.
        /// </summary>
        [JsonProperty("direct_from_body")]
        public bool? IsDirectFromBody { get; set; }

        /// <summary>
        /// Gets or sets the is older available.
        /// </summary>
        [JsonProperty("older_available")]
        public bool? IsOlderAvailable { get; set; }

        /// <summary>
        /// Gets or sets the last seen message id.
        /// </summary>
        [JsonProperty("last_seen_message_id")]
        public long? LastSeenMessageId { get; set; }

        /// <summary>
        /// Gets or sets the liked message ids.
        /// </summary>
        [JsonProperty("liked_message_ids")]
        public long[] LikedMessageIds { get; set; }

        /// <summary>
        /// Gets or sets the Realtime API information.
        /// </summary>
        [JsonProperty("realtime")]
        public Realtime Realtime { get; set; }

        /// <summary>
        /// Gets or sets the requested poll interval.
        /// </summary>
        [JsonProperty("requested_poll_interval")]
        public int? RequestedPollInterval { get; set; }

        /// <summary>
        /// Gets or sets the show billing banner.
        /// </summary>
        [JsonProperty("show_billing_banner")]
        public bool? ShowBillingBanner { get; set; }

        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
        [JsonProperty("sort_by")]
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets the threads in inbox.
        /// </summary>
        [JsonProperty("threads_in_inbox")]
        public long[] ThreadsInInbox { get; set; }

        /// <summary>
        /// Gets or sets the unseen message count all feed.
        /// </summary>
        [JsonProperty("unseen_message_count_my_all")]
        public int? UnseenMessageCountAllFeed { get; set; }

        /// <summary>
        /// Gets or sets the unseen message count featured feed.
        /// </summary>
        [JsonProperty("unseen_message_count_algo")]
        public int? UnseenMessageCountFeaturedFeed { get; set; }

        /// <summary>
        /// Gets or sets the unseen message count following feed.
        /// </summary>
        [JsonProperty("unseen_message_count_following")]
        public int? UnseenMessageCountFollowingFeed { get; set; }

        /// <summary>
        /// Gets or sets the unseen message count received.
        /// </summary>
        [JsonProperty("unseen_message_count_received")]
        public int? UnseenMessageCountReceived { get; set; }

        /// <summary>
        /// Gets or sets the unseen thread count featured feed.
        /// </summary>
        [JsonProperty("unseen_thread_count_algo")]
        public int? UnseenThreadCountFeaturedFeed { get; set; }

        /// <summary>
        /// Gets or sets the unseen thread count all feed.
        /// </summary>
        [JsonProperty("unseen_thread_count_my_all")]
        public int? UnseenThreadCountAllFeed { get; set; }

        /// <summary>
        /// Gets or sets the unseen thread count following feed.
        /// </summary>
        [JsonProperty("unseen_thread_count_following")]
        public int? UnseenThreadCountFollowingFeed { get; set; }

        /// <summary>
        /// Gets or sets the unseen thread count received.
        /// </summary>
        [JsonProperty("unseen_thread_count_received")]
        public int? UnseenThreadCountReceived { get; set; }

        /// <summary>
        /// Gets or sets the YModules.
        /// </summary>
        [JsonProperty("ymodules")]
        public YModule[] YModules { get; set; }
    }
}
