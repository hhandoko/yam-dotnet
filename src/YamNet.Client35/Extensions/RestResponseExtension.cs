// -----------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Net;
    using System.Web;

    using RestSharp;

    /// <summary>
    /// RestSharp.RestResponse extension.
    /// </summary>
    internal static class RestResponseExtension
    {
        /// <summary>
        /// Check if response status code is HTTP 200 (OK).
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsSuccessStatusCode(this RestResponse response)
        {
            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Ensure that response is successful (HTTP 200 (OK)) or throw an error.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>The <see cref="RestResponse"/>.</returns>
        public static RestResponse EnsureSuccessStatusCode(this RestResponse response)
        {
            // Check if HTTP status is 200 (OK),
            // if so, return the response
            if (response.IsSuccessStatusCode())
            {
                return response;
            }

            // Empty out the response
            response.Content = null;

            throw new HttpException((int)response.StatusCode, response.ErrorMessage);
        }
    }
}
