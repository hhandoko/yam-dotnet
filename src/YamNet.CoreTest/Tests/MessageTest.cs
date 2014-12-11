// -----------------------------------------------------------------------
// <copyright file="MessageTest.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Linq;

    using YamNet.Client.Undocumented;

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
            foreach (var message in client.Messages.GetAll().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            var references = client.Messages.GetAll().Result.References;
            Console.WriteLine("\n{0}. Get a summary of the \"All\" messages references", j++);
            i = 1;
            Console.WriteLine("   1 - Messages: {0}", references.Count(q => q.Type == "message"));
            Console.WriteLine("   2 - Tags    : {0}", references.Count(q => q.Type == "user"));
            Console.WriteLine("   3 - Topics  : {0}", references.Count(q => q.Type == "topic"));
            Console.WriteLine("   4 - Users   : {0}", references.Count(q => q.Type == "user"));

            Console.WriteLine("\n{0}. Get first five of the \"All\" messages User references", j++);
            i = 1;
            foreach (UserReference user in references.Where(q => q.Type == "user").Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, user.FullName);
                i++;
            }
            
            Console.WriteLine("\n{0}. Get first five \"Feed\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetFeed().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five \"Top\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetTop().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five \"Following\" messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetFollowing().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five sent inbox messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetSent().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five private inbox messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetPrivate().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. Get first five inbox messages", j++);
            i = 1;
            foreach (var message in client.Messages.GetReceived().Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }

            Console.WriteLine("\n{0}. (UNDOC) Get first five messages from one of user's group", j++);
            var currentUser = client.Users.Current(includeGroups: true, includeFollowed: true).Result;
            var firstGroupId = currentUser.GroupMemberships.First().Id;
            i = 1;
            foreach (var message in client.Messages.GetByGroupId(firstGroupId).Result.Messages.Take(5))
            {
                Console.WriteLine("   {0} - {1}", i, message.MessageBody.Plain.ConsoleTrim(Chars));
                i++;
            }
        }
    }
}
