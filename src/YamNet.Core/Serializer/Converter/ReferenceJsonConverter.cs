// -----------------------------------------------------------------------
// <copyright file="ReferenceJsonConverter.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The Reference JSON converter.
    /// </summary>
    internal class ReferenceJsonConverter : JsonConverter
    {
        /// <summary>
        /// The converter type mapping.
        /// </summary>
        private static readonly Dictionary<string, Type> TypeMap =
            new Dictionary<string, Type>
                {
                    // User types
                    { "user", typeof(UserReference) },
                    { "guide", typeof(UserReference) },
                    { "bot", typeof(UserReference) },
                    // Other reference types
                    { "conversation", typeof(ConversationReference) },
                    { "message", typeof(MessageReference) },
                    { "thread", typeof(ThreadReference) },
                    { "shared_thread", typeof(SharedThreadReference) },
                    { "group", typeof(GroupReference) },
                    { "tag", typeof(TagReference) },
                    { "topic", typeof(TopicReference) }
                };

        /// <summary>
        /// Gets a value indicating whether the converter can read.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this converter can write.
        /// </summary>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// Returns true if the object can be converted
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return 
                objectType == typeof(IReference[])
                || objectType == typeof(IList<IReference>);
        }

        /// <summary>
        /// Read from a JSON object.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">The object type.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            return
                JArray.Load(reader)
                    .Where(i => TypeMap.ContainsKey(i["type"].ToString()))
                    .Select(i => (IReference)serializer.Deserialize(i.CreateReader(), TypeMap[i["type"].ToString()]))
                    .ToArray();
        }
        
        /// <summary>
        /// Write to a JSON object.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter cannot write.");
        }
    }
}
