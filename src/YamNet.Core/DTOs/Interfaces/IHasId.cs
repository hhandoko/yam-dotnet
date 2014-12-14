// -----------------------------------------------------------------------
// <copyright file="IHasId.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    /// <summary>
    /// Has an ID.
    /// </summary>
    /// <typeparam name="TId">The ID type.</typeparam>
    internal interface IHasId<TId>
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        TId Id { get; set; }
    }
}
