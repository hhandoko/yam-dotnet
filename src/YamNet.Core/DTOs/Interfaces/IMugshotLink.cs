// -----------------------------------------------------------------------
// <copyright file="IMugshotLink.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    /// <summary>
    /// The mugshot links.
    /// </summary>
    interface IMugshotLink
    {
        /// <summary>
        /// Gets or sets the mugshot url.
        /// </summary>
        Uri MugshotUrl { get; set; }

        /// <summary>
        /// Gets or sets the mugshot url template.
        /// </summary>
        string MugshotUrlTemplate { get; set; }
    }
}
