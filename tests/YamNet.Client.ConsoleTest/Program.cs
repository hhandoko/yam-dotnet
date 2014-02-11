// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The console program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var token = ConfigurationManager.AppSettings["access_token"];

            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Note: Access Token not detected in App.Config.");
                Console.Write("      Please type the token and press 'Enter': ");
                token = Console.ReadLine();
                Console.Clear();
            }

            // Get the Yammer API client, and pass in the access token
            using (var client = new Client(token))
            {
                // Run Tests
                client.RunUserTest();
                Console.WriteLine("\n");
                client.RunMessageTest();
            }

            // Finish!
            Console.WriteLine("\nCompleted. Press any key to finish...");
            Console.ReadKey();
        }
    }
}
