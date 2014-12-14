// -----------------------------------------------------------------------
// <copyright file="IHomeTab.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    /// <summary>
    /// The user's home tab interface.
    /// </summary>
    public interface IHomeTab
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the selected name.
        /// </summary>
        string SelectName { get; set; }

        /// <summary>
        /// Gets or sets the tab type.
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Gets or sets the feed description.
        /// </summary>
        string FeedDescription { get; set; }

        /// <summary>
        /// Gets or sets the ordering index.
        /// </summary>
        string OrderingIndex { get; set; }

        /// <summary>
        /// Gets or sets the tab API URL.
        /// </summary>
        Uri Url { get; set; }
    }
}
