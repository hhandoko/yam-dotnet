// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Configuration;
    using System.Linq;

    /// <summary>
    /// The console program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            // Get the Yammer API client, and pass in the access token
            var client = new Client(ConfigurationManager.AppSettings["access_token"]);

            // User Tests
            TestUser(client);

            // Finish!
            Console.WriteLine("\nCompleted. Press any key to finish...");
            Console.ReadKey();
        }

        /// <summary>
        /// Create header texts.
        /// </summary>
        /// <param name="title">
        /// The title.
        /// </param>
        private static void WriteHeader(string title)
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
        /// Test UserClient APIs.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        private static void TestUser(Client client)
        {
            WriteHeader("User");

            var i = 1;
            var j = 1;

            Console.WriteLine("1. Get first five users");
            i = 1;
            foreach (var user in client.Users.Get().Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }
            
            Console.WriteLine("\n2. Get last five users");
            i = 1;
            foreach (var user in client.Users.Get(reverse: true).Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }

            Console.WriteLine("\n3. Get three users whose name starts with \"F\"");
            i = 1;
            foreach (var user in client.Users.Get(letter: "F").Take(3))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }

            Console.WriteLine("\n4. Get three most active users");
            i = 1;
            foreach (var user in client.Users.Get(sort: UserQuerySort.Messages).Take(3))
            {
                Console.WriteLine("   {0} - {1} with {2} updates", i, user.FullName, user.Stats.Updates);
                i++;
            }

            Console.WriteLine("\n5. Get three most replied-to users");
            i = 1;
            foreach (var user in client.Users.Get(sort: UserQuerySort.Followers).Take(3))
            {
                Console.WriteLine("   {0} - {1} with {2} replies", i, user.FullName, user.Stats.Followers);
                i++;
            }
            
            Console.WriteLine("\n6. Get the current account");
            var currentUser = client.Users.Current(includeGroups: true);
            var currentUserEmail = currentUser.ContactInfo.EmailAddresses.FirstOrDefault(x => x.Type == "primary").Address;
            var sampleGroup = currentUser.GroupMemberships.FirstOrDefault(x => x.IsPublic);
            Console.WriteLine("   Id       : {0}", currentUser.Id);
            Console.WriteLine("   Name     : {0}", currentUser.FullName);
            Console.WriteLine("   Email    : {0}", currentUserEmail);
            Console.WriteLine("   Job Title: {0}", currentUser.JobTitle);

            Console.WriteLine("\n7. Get the account by its id ({0})", currentUser.Id);
            Console.WriteLine("   Name     : {0}", client.Users.GetById(currentUser.Id).FullName);

            Console.WriteLine("\n8. Get the account by its email ({0})", currentUserEmail);
            Console.WriteLine("   Name     : {0}", client.Users.GetByEmail(currentUserEmail).FullName);

            Console.WriteLine("\n9. Get the groups the user a member of");
            i = 1;
            foreach (var group in currentUser.GroupMemberships)
            {
                Console.WriteLine("   {0} - {1}", i, group.FullName);
                i++;
            }
            
            Console.WriteLine("\n10. Get up to ten members of a group the user is a member of ({0})", sampleGroup.FullName);
            i = 1;
            foreach (var members in client.Users.GetByGroupId(sampleGroup.Id).Take(10))
            {
                Console.WriteLine("   {0} - {1}", i, members.FullName);
                i++;
            }
        }
    }
}
