// -----------------------------------------------------------------------
// <copyright file="LoadingSpinner.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.ConsoleTest
{
    using System;

    /// <summary>
    /// The loading spinner.
    /// </summary>
    public class LoadingSpinner
    {
        /// <summary>
        /// The counter.
        /// </summary>
        private int counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingSpinner"/> class.
        /// </summary>
        public LoadingSpinner()
        {
            this.counter = 0;
        }

        /// <summary>
        /// Play the loading spinner.
        /// </summary>
        public void Play()
        {
            this.counter++;

            switch (this.counter % 8)
            {
                case 0: Console.Write("[...    ]"); break;
                case 1: Console.Write("[ ...   ]"); break;
                case 2: Console.Write("[  ...  ]"); break;
                case 3: Console.Write("[   ... ]"); break;
                case 4: Console.Write("[    ...]"); break;
                case 5: Console.Write("[   ... ]"); break;
                case 6: Console.Write("[  ...  ]"); break;
                case 7: Console.Write("[ ...   ]"); break;
            }

            Console.SetCursorPosition(Console.CursorLeft - 9, Console.CursorTop);
        }
    }
}
