﻿// -----------------------------------------------------------------------
// <copyright file="IDeserializer.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Text;

    using Newtonsoft.Json;

    /// <summary>
    /// The Deserializer interface.
    /// </summary>
    public interface IDeserializer
    {
        /// <summary>
        /// Gets the text encoding.
        /// </summary>
        Encoding TextEncoding { get; }

        /// <summary>
        /// Gets the deserializer settings.
        /// </summary>
        JsonSerializerSettings DeserializerSettings { get; }

        /// <summary>
        /// Deserialize bytes content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        T Deserialize<T>(byte[] content);

        /// <summary>
        /// Deserialize string content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <typeparam name="T">The object type.</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        T Deserialize<T>(string content);
    }
}
