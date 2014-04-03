// -----------------------------------------------------------------------
// <copyright file="JsonDotNetDeserializer.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Text;

    using Newtonsoft.Json;

    /// <summary>
    /// The JSON.Net deserializer.
    /// </summary>
    public class JsonDotNetDeserializer : IDeserializer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDotNetDeserializer" /> class.
        /// </summary>
        /// <param name="encoding">The encoding.</param>
        public JsonDotNetDeserializer(Encoding encoding = null)
        {
            this.TextEncoding = encoding ?? Encoding.UTF8;

            this.DeserializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        /// <summary>
        /// Gets or sets the text encoding.
        /// </summary>
        public Encoding TextEncoding { get; protected set; }

        /// <summary>
        /// Gets or sets the deserializer settings.
        /// </summary>
        public JsonSerializerSettings DeserializerSettings { get; protected set; }

        /// <summary>
        /// Deserializes the specified content.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>The deserialized object</returns>
        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, this.DeserializerSettings);
        }

        /// <summary>
        /// Deserializes the async.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="content">The content.</param>
        /// <returns>The deserialized object</returns>
        public T Deserialize<T>(byte[] content)
        {
            return this.Deserialize<T>(this.TextEncoding.GetString(content, 0, content.Length));
        }
    }
}
