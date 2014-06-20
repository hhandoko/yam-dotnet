// -----------------------------------------------------------------------
// <copyright file="UserContact.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user contact.
    /// </summary>
    public sealed class UserContact
    {
        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        [JsonProperty("phone_numbers")]
        public UserPhoneNumber[] PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the email addresses.
        /// </summary>
        [JsonProperty("email_addresses")]
        public UserEmailAddress[] EmailAddresses { get; set; }

        /// <summary>
        /// Gets or sets the user instant messaging (IM) contact.
        /// </summary>
        [JsonProperty("im")]
        public UserIm Im { get; set; }
    }
}