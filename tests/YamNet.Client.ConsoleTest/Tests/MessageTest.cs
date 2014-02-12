// -----------------------------------------------------------------------
// <copyright file="MessageTest.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;
    using System.Linq;

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
}
