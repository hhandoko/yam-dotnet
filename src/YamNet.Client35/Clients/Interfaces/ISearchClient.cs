// -----------------------------------------------------------------------
// <copyright file="ISearchClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    /// <summary>
    /// The SearchClient interface.
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        /// Search groups, pages, topics, and users that matches the search query.
        /// </summary>
        /// <param name="queryText">The query text to search.</param>
        /// <param name="pageNo">The page number for (paged) search results.</param>
        /// <param name="resultsPerPage">The number of search results per page, up to 20.</param>
        /// <returns>The <see cref="Task{SearchEnvelope}"/>.</returns>
        Task<SearchEnvelope> Search(string queryText, int pageNo, int resultsPerPage);
    }
}
