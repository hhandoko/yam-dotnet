// -----------------------------------------------------------------------
// <copyright file="JsonServiceClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;

    public partial class JsonServiceClient : IDisposable
    {
        /// <summary>
        /// Denotes whether client has been disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonServiceClient"/> class.
        /// </summary>
        /// <param name="token">The access token.</param>
        public JsonServiceClient(string token)
        {
            this.Init(token);
        }

        /// <summary>
        /// Gets or sets the serializer.
        /// </summary>
        public ISerializer Serializer { get; set; }

        /// <summary>
        /// Gets or sets the deserializer.
        /// </summary>
        public IDeserializer Deserializer { get; set; }

        /// <summary>
        /// Gets or sets the response error handler.
        /// </summary>
        public IResponseErrorHandler ResponseErrorHandler { get; set; }

        /// <summary>
        /// Gets or sets the URI / URL endpoint.
        /// </summary>
        internal Uri Endpoint { get; set; }
    }
}
