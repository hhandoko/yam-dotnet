// -----------------------------------------------------------------------
// <copyright file="HomeTabConverter.cs" company="YamNet">
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
    /// The home tab type JSON converter.
    /// </summary>
    internal class HomeTabConverter : JsonConverter
    {
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
                objectType == typeof(IHomeTab[])
                || objectType == typeof(IList<IHomeTab>);
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
                    .Select(i => (IHomeTab)serializer.Deserialize(i.CreateReader(), GetMappingType(i["type"].ToString())))
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

        /// <summary>
        /// Get the mapping type from the object type property.
        /// </summary>
        /// <param name="type">The object type property string.</param>
        /// <returns>The object type.</returns>
        private static Type GetMappingType(string type)
        {
            return type == "group" ? typeof(UserGroupTab) : typeof(UserStandardTab);
        }
    }
}
