// -----------------------------------------------------------------------
// <copyright file="IReference.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    /// <summary>
    /// The Reference interface.
    /// </summary>
    public interface IReference
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        long Id { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the display value.
        /// </summary>
        string DisplayValue { get; }
    }
}
