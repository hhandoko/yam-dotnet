// -----------------------------------------------------------------------
// <copyright file="ConsoleHelper.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The console helper.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Create header texts.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        public static void WriteHeader(string title)
        {
            var text = string.Format("-- {0} --", title);
            var divider = new string('-', text.Length);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(divider);
            Console.WriteLine(text);
            Console.WriteLine(divider);

            Console.ResetColor();
        }

        /// <summary>
        /// Trim string for console output.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ConsoleTrim(this string value, int length)
        {
            var output = String.Empty;

            // Source: http://stackoverflow.com/a/206946/1615437
            output = Regex.Replace(value, @"\s+", " ").RemoveLineEndings();

            if (output.Length >= length)
            {
                return output.Substring(0, length) + "...";
            }

            return output;
        }

        /// <summary>
        /// Remove line endings.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <remarks>
        /// Source:
        /// http://stackoverflow.com/a/6765676/1615437
        /// </remarks>
        private static string RemoveLineEndings(this string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }

            var lineSeparator = ((char)0x2028).ToString();
            var paragraphSeparator = ((char)0x2029).ToString();

            return
                value.Replace("\r\n", String.Empty)
                    .Replace("\n", String.Empty)
                    .Replace("\r", String.Empty)
                    .Replace(lineSeparator, String.Empty)
                    .Replace(paragraphSeparator, String.Empty);
        }
    }
}
