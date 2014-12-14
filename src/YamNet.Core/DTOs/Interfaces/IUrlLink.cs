// -----------------------------------------------------------------------
// <copyright file="IUrlLink.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    /// <summary>
    /// The web and API links.
    /// </summary>
    interface IUrlLink
    {
        /// <summary>
        /// Gets or sets the API URL link.
        /// </summary>
        Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the website URL link.
        /// </summary>
        Uri WebUrl { get; set; }
    }
}
