// -----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Linq;

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
            return
                !IsNullOrWhiteSpace(value)
                && Uri.IsWellFormedUriString(value, uriKind);
        }

        /// <summary>
        /// Convert the string to a valid URI.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="uriKind">The uri kind.</param>
        /// <returns>The <see cref="Uri"/>, or null if it is invalid URI.</returns>
        public static Uri ToUri(this string value, UriKind uriKind = UriKind.Absolute)
        {
            return
                (IsNullOrWhiteSpace(value) || !Uri.IsWellFormedUriString(value, uriKind))
                    ? null
                    : new Uri(value, uriKind);
        }

        /// <summary>
        /// .Net 3.5 string.IsNullOrWhiteSpace() implementation.
        /// Reference: http://stackoverflow.com/a/10251167/1615437
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static bool IsNullOrWhiteSpace(string value)
        {
            return value == null || value.All(char.IsWhiteSpace);
        }
    }
}
