// -----------------------------------------------------------------------
// <copyright file="QueryExtension.cs" company="YamNet">
//   Copyright (c) 2013 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System;
    using System.Linq;

    /// <summary>
    /// The query extension.
    /// </summary>
    public static class QueryExtension
    {
        /// <summary>
        /// Serialise the query object into querystring.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <remarks>
        /// Using both reflection and LINQ, and UrlEncode replaced with PCL equivalent.
        /// Source: http://stackoverflow.com/questions/6848296/how-do-i-serialize-an-object-into-query-string-format
        /// Source: http://stackoverflow.com/questions/11473031/portable-class-library-httputility-urlencode
        /// </remarks>
        public static string SerializeQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select string.Format("{0}={1}", p.Name.ToLowerInvariant(), Uri.EscapeDataString(p.GetValue(obj, null).ToString().ToLowerInvariant()));

            return string.Join("&", properties.ToArray());
        }
    }
}
