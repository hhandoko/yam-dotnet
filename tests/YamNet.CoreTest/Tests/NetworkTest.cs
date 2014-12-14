// -----------------------------------------------------------------------
// <copyright file="UserTest.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;

    /// <summary>
    /// The user's network test.
    /// </summary>
    public static class NetworkTest
    {
        /// <summary>
        /// Test NetworkClient APIs.
        /// </summary>
        /// <param name="client">The client.</param>
        public static void RunNetworkTest(this Client client)
        {
            ConsoleHelper.WriteHeader("Network");

            var i = 1;
            var j = 1;

            Console.WriteLine("{0}. Get user's networks", j++);
            i = 1;
            foreach (var network in client.Networks.Current().Result)
            {
                Console.WriteLine("   {0} - {1}", i, network.Name);
                i++;
            }
        }
    }
}
