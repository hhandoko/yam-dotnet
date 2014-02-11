// -----------------------------------------------------------------------
// <copyright file="MessageBody.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    /// <summary>
    /// The message body.
    /// </summary>
    public sealed class MessageBody
    {
        /// <summary>
        /// The stringified urls.
        /// </summary>
        private string[] urlsStringified;

        /// <summary>
        /// The urls.
        /// </summary>
        private List<Uri> urls = new List<Uri>();

        /// <summary>
        /// Gets or sets the parsed message body.
        /// </summary>
        [JsonProperty("parsed")]
        public string Parsed { get; set; }

        /// <summary>
        /// Gets or sets the message body in plain text.
        /// </summary>
        [JsonProperty("plain")]
        public string Plain { get; set; }

        /// <summary>
        /// Gets or sets the message body in rich text / HTML.
        /// </summary>
        [JsonProperty("rich")]
        public string RichText { get; set; }

        /// <summary>
        /// Gets or sets the urls stringified.
        /// </summary>
        /// <remarks>
        /// This property is for internal use only.
        /// Its only purpose is to translate stringified Uris into valid Uri.
        /// </remarks>
        [JsonProperty("urls")]
        internal string[] UrlsStringified
        {
            get
            {
                return this.urlsStringified;
            }

            set
            {
                this.urlsStringified = value;
                if (this.urlsStringified != null)
                {
                    this.urls.Clear();
                    this.urls.AddRange(this.urlsStringified.Where(x => x.IsUri()).Select(x => x.ToUri()));
                }
            }
        }

        /// <summary>
        /// Gets the urls.
        /// </summary>
        public IList<Uri> Urls
        {
            get { return this.urls; }
        }
    }
}