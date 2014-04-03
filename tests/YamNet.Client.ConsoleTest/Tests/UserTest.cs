// -----------------------------------------------------------------------
// <copyright file="UserTest.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Linq;

    /// <summary>
    /// The user test.
    /// </summary>
    public static class UserTest
    {
        /// <summary>
        /// Test UserClient APIs.
        /// </summary>
        /// <param name="client">The client.</param>
        public static void RunUserTest(this Client client)
        {
            ConsoleHelper.WriteHeader("User");

            var i = 1;
            var j = 1;

            Console.WriteLine("{0}. Get first five users", j++);
            i = 1;
            foreach (var user in client.Users.Get().Result.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }

            Console.WriteLine("\n{0}. Get last five users", j++);
            i = 1;
            foreach (var user in client.Users.Get(reverse: true).Result.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }

            Console.WriteLine("\n{0}. Get three users whose name starts with \"F\"", j++);
            i = 1;
            foreach (var user in client.Users.Get(letter: "F").Result.Take(3))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }

            Console.WriteLine("\n{0}. Get three most active users", j++);
            i = 1;
            foreach (var user in client.Users.Get(sort: UserQuerySort.Messages).Result.Take(3))
            {
                Console.WriteLine("   {0} - {1} with {2} updates", i, user.FullName, user.Stats.Updates);
                i++;
            }

            Console.WriteLine("\n{0}. Get three most replied-to users", j++);
            i = 1;
            foreach (var user in client.Users.Get(sort: UserQuerySort.Followers).Result.Take(3))
            {
                Console.WriteLine("   {0} - {1} with {2} replies", i, user.FullName, user.Stats.Followers);
                i++;
            }

            Console.WriteLine("\n{0}. Get the current account, with group membership and followed users info", j++);
            var currentUser =  client.Users.Current(includeGroups: true, includeFollowed: true).Result;
            var currentUserEmail = currentUser.ContactInfo.EmailAddresses.FirstOrDefault(x => x.Type == "primary").Address;
            var sampleGroup = currentUser.GroupMemberships.FirstOrDefault(x => x.IsPublic);
            Console.WriteLine("   Id       : {0}", currentUser.Id);
            Console.WriteLine("   Name     : {0}", currentUser.FullName);
            Console.WriteLine("   Email    : {0}", currentUserEmail);
            Console.WriteLine("   Job Title: {0}", currentUser.JobTitle);

            Console.WriteLine("\n{0}. Get the account by its id ({1})", j++, currentUser.Id);
            Console.WriteLine("   Name     : {0}", client.Users.GetById(currentUser.Id).Result.FullName);

            Console.WriteLine("\n{0}. Get the account by its email ({1})", j++, currentUserEmail);
            Console.WriteLine("   Name     : {0}", client.Users.GetByEmail(currentUserEmail).Result.FullName);

            Console.WriteLine("\n{0}. Get up to five accounts being followed by the user", j++);
            i = 1;
            foreach (var followed in currentUser.FollowedUsers.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, followed.FullName);
                i++;
            }
            
            Console.WriteLine("\n{0}. Get the user's org chart relationship", j++);
            var currentRelations = client.Relationships.GetCurrent().Result;
            Console.WriteLine("   Superior    : {0}", string.Join(", ", (from r in currentRelations.Superiors.ToList() select r.FullName).ToArray()).ConsoleTrim(69));
            Console.WriteLine("   Colleagues  : {0}", string.Join(", ", (from r in currentRelations.Colleagues.ToList() select r.FullName).ToArray()).ConsoleTrim(69));
            Console.WriteLine("   Subordinates: {0}", string.Join(", ", (from r in currentRelations.Subordinates.ToList() select r.FullName).ToArray()).ConsoleTrim(69));

            if (currentRelations.Superiors.Any())
            {
                Console.WriteLine("\n{0}. Get the user's manager org chart relationship", j++);
                var managerRelations = client.Relationships.GetById(currentRelations.Superiors.First().Id).Result;
                Console.WriteLine("   Superior    : {0}", string.Join(", ", (from r in managerRelations.Superiors.ToList() select r.FullName).ToArray()).ConsoleTrim(69));
                Console.WriteLine("   Colleagues  : {0}", string.Join(", ", (from r in managerRelations.Colleagues.ToList() select r.FullName).ToArray()).ConsoleTrim(69));
                Console.WriteLine("   Subordinates: {0}", string.Join(", ", (from r in managerRelations.Subordinates.ToList() select r.FullName).ToArray()).ConsoleTrim(69));
            }

            Console.WriteLine("\n{0}. Get the groups the user a member of", j++);
            i = 1;
            foreach (var group in currentUser.GroupMemberships)
            {
                Console.WriteLine("   {0} - {1}", i, group.FullName);
                i++;
            }

            Console.WriteLine("\n{0}. Get up to ten members of a group the user is a member of ({1})", j++, sampleGroup.FullName);
            i = 1;
            foreach (var members in client.Users.GetByGroupId(sampleGroup.Id).Result.Take(10))
            {
                Console.WriteLine("   {0} - {1}", i, members.FullName);
                i++;
            }
        }
    }
}
