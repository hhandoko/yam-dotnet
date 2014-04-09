// -----------------------------------------------------------------------
// <copyright file="TokenNotFoundException.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
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