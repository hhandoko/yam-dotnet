// -----------------------------------------------------------------------
// <copyright file="ConsoleHelper.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;

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
    }
}
