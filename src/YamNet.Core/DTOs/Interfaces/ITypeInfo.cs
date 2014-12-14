// -----------------------------------------------------------------------
// <copyright file="ITypeInfo.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    /// <summary>
    /// The Object Graph type info.
    /// </summary>
    internal interface ITypeInfo
    {
        /// <summary>
        /// Gets or sets the OG object type.
        /// </summary>
        string Type { get; set; }
    }
}
