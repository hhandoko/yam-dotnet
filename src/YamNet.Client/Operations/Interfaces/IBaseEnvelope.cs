// -----------------------------------------------------------------------
// <copyright file="IBaseEnvelope.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    /// <summary>
    /// The BaseEnvelope interface.
    /// </summary>
    /// <typeparam name="T">The class type.</typeparam>
    public interface IBaseEnvelope<T>
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        T Content { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        Exception Exception { get; set; }

        /// <summary>
        /// Gets a value indicating whether is faulted.
        /// </summary>
        bool IsFaulted { get; }

        /// <summary>
        /// The result.
        /// </summary>
        /// <returns>The <see cref="T"/>.</returns>
        T Result();
    }
}
