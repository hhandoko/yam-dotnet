// -----------------------------------------------------------------------
// <copyright file="MessageTest.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The user message test.
    /// </summary>
    public static class MessageTest
    {
        /// <summary>
        /// Test MessageClient APIs.
        /// </summary>
        /// <param name="client">The client.</param>
        public static void RunMessageTest(this Client client)
        {
            ConsoleHelper.WriteHeader("Message");

            const int Chars = 69;

            var i = 1;
            var j = 1;

            Console.WriteLine("{0}. Get first five \"All\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetAll().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five \"Feed\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetFeed().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five \"Top\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetTop().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five \"Following\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetFollowing().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five sent inbox messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetSent().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five private inbox messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetPrivate().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five inbox messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetReceived().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }
        }
    }

    /// <summary>
    /// The MessageClient test extension.
    /// </summary>
    internal static class MessageTestExtension
    {
        /// <summary>
        /// Trim string for console output.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ConsoleTrim(this string value, int length)
        {
            var output = string.Empty;

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
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var lineSeparator = ((char)0x2028).ToString();
            var paragraphSeparator = ((char)0x2029).ToString();

            return
                value.Replace("\r\n", string.Empty)
                     .Replace("\n", string.Empty)
                     .Replace("\r", string.Empty)
                     .Replace(lineSeparator, string.Empty)
                     .Replace(paragraphSeparator, string.Empty);
        }
    }
}
