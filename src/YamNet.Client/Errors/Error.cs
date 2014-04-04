// -----------------------------------------------------------------------
// <copyright file="Error.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Errors
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// The error DTO.
    /// </summary>
    /// <remarks>
    /// For serializing API response, like:
    /// {
    ///     "response": {
    ///         "message": "Token not found.",
    ///         "code": 16,
    ///         "stat": "fail"
    ///     }
    /// }
    /// </remarks>
    public class Error
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message
        {
            get { return this.Response["message"].ToString(); }
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        public int Code
        {
            get
            {
                int code;

                return int.TryParse(this.Response["code"].ToString(), out code)
                    ? code
                    : int.MinValue;
            }
        }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        [JsonProperty("response")]
        protected Dictionary<string, object> Response { get; set; }

        /// <summary>
        /// Denotes whether the response is a valid response.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool IsValid()
        {
            return this.Response != null;
        }
    }
}
