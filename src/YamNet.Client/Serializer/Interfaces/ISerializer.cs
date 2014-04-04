// -----------------------------------------------------------------------
// <copyright file="ISerializer.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    /// <summary>
    /// The Serializer interface.
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Gets the content type.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Serialize to byte array.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="byte[]"/>.</returns>
        byte[] SerializeToByteArray(object obj);

        /// <summary>
        /// Serialize to string. 
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="string"/>.</returns>
        string Serialize(object obj);
    }
}
