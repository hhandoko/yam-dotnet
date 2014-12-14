// -----------------------------------------------------------------------
// <copyright file="UserContact.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using Newtonsoft.Json;

    /// <summary>
    /// The user contact information.
    /// </summary>
    /// <remarks>
    /// DTO last checked     : 2014/12/14
    /// Sample last retrieved: 2014/12/14 
    /// 
    /// GET: https://www.yammer.com/api/v1/users/current.json 
    /// contact: {
    ///     im: {
    ///         provider: "aim",
    ///         username: ""
    ///     },
    ///     phone_numbers: [
    ///         {
    ///             type: "work",
    ///             number: "+61898765432 x432"
    ///         },
    ///         {
    ///             type: "mobile",
    ///             number: "+61401234567"
    ///         }
    ///     ],
    ///     email_addresses: [
    ///         {
    ///             type: "primary",
    ///             address: "joe.bloggs@somenetwork.com"
    ///         }
    ///     ],
    ///     has_fake_email: false
    /// }
    /// </remarks>
    public sealed class UserContact
    {
        /// <summary>
        /// Gets or sets the user instant messaging (IM) contact.
        /// </summary>
        [JsonProperty("im")]
        public UserIm Im { get; set; }

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
        /// Gets or sets a value indicating whether a fake email address is used.
        /// </summary>
        [JsonProperty("has_fake_email")]
        public bool HasFakeEmail { get; set; }
    }
}