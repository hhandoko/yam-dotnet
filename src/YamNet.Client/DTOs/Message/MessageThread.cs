// -----------------------------------------------------------------------
// <copyright file="MessageThread.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Collections.Generic;

    /// <summary>
    /// Thread messages indexed by thread id (as a string).
    /// </summary>
    public class MessageThread : Dictionary<string, Message[]>
    {
    }
}
