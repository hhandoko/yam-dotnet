// -----------------------------------------------------------------------
// <copyright file="IReference.cs" company="YamNet">
//   Copyright (c) YamNet 2014 and Contributors
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
