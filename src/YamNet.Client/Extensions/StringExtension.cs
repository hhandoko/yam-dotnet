// -----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    /// <summary>
    /// The string extension methods.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Checks whether the supplied string is a valid URI.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="uriKind">The uri kind.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsUri(this string value, UriKind uriKind = UriKind.Absolute)
        {
            return !string.IsNullOrWhiteSpace(value) && Uri.IsWellFormedUriString(value, uriKind);
        }
    }
}
