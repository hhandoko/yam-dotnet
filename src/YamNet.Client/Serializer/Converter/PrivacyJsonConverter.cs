// -----------------------------------------------------------------------
// <copyright file="PrivacyJsonConverter.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The privacy json converter.
    /// </summary>
    internal class PrivacyJsonConverter : JsonConverter
    {
        /// <summary>
        /// Gets a value indicating whether can read.
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
            return objectType == typeof(string);
        }

        /// <summary>
        /// Read from a JSON object.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="objectType">The object type.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value;

            return string.Equals(value as string, "public", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Write to a JSON object.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The serializer.</param>
        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter cannot write.");
        }
    }
}
