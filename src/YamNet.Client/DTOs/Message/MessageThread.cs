// -----------------------------------------------------------------------
// <copyright file="MessageThread.cs" company="YamNet">
//   Copyright (c) YamNet 2014 and Contributors
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
