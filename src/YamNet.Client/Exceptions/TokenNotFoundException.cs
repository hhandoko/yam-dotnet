// -----------------------------------------------------------------------
// <copyright file="TokenNotFoundException.cs" company="YamNet">
//   Copyright (c) YamNet 2013 and Contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Exceptions
{
    using System;

    /// <summary>
    /// The token not found exception.
    /// </summary>
    /// <remarks>
    /// When received in an error response, means our token
    /// has expired or is revoked :(
    /// </remarks>
    public class TokenNotFoundException : Exception
    {
    }
}