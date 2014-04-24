// -----------------------------------------------------------------------
// <copyright file="SearchClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Threading.Tasks;

    using Config = ClientConfiguration;

    /// <summary>
    /// Yammer search client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-search
    /// </remarks>
    public class SearchClient : ClientBase, ISearchClient
    {
        /// <summary>
        /// The search client base uri.
        /// </summary>
        private const string BaseUri = "/search";

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public SearchClient(Client client)
            : base(client)
        {
        }

        // TODO: Create 'messages', and 'users' response.
        // TODO: Add integration test for topics
        /// <summary>
        /// Search groups, pages, topics, and users that matches the search query.
        /// </summary>
        /// <param name="queryText">The search query text.</param>
        /// <param name="pageNo">The page number for (paged) search results.</param>
        /// <param name="resultsPerPage">The number of search results per page, up to 20.</param>
        /// <returns>The <see cref="SearchEnvelope"/>.</returns>
        public async Task<SearchEnvelope> Search(string queryText, int pageNo = Config.DefaultPageNo, int resultsPerPage = Config.Search.DefaultResultsPerPage)
        {
            var query = new SearchQuery(queryText, pageNo, resultsPerPage);
            var url = GetFinalUrl(string.Format("{0}.json", BaseUri), query.SerializeQueryString());
            var result = await this.Client.GetAsync<SearchEnvelope>(url);

            return result.Content;
        }
    }

    /// <summary>
    /// The SearchClient query helper. 
    /// </summary>
    public class SearchQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchQuery"/> class.
        /// </summary>
        /// <param name="queryText">The query text to search.</param>
        /// <param name="pageNo">The page number for (paged) search results.</param>
        /// <param name="resultsPerPage">The number of search results per page, up to 20.</param>
        public SearchQuery(string queryText, int pageNo, int resultsPerPage)
        {
            if (pageNo > 0 && pageNo != Config.DefaultPageNo)
            {
                Page = pageNo;
            }

            if (resultsPerPage > 0
                && resultsPerPage != Config.Search.DefaultResultsPerPage
                && resultsPerPage <= Config.Search.MaxResultsPerPage)
            {
                Num_Per_Page = resultsPerPage;
            }

            Search = queryText;
        }

        /// <summary>
        /// Gets or sets the page number for paged result.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the number of results per page.
        /// </summary>
        public int? Num_Per_Page { get; set; }

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Search { get; set; }
    }

    /// <summary>
    /// The shared client configuration.
    /// </summary>
    internal static partial class ClientConfiguration
    {
        /// <summary>
        /// The SearchClient configuration.
        /// </summary>
        internal static class Search
        {
            /// <summary>
            /// The default number of results returned per page.
            /// </summary>
            public const int DefaultResultsPerPage = 20;

            /// <summary>
            /// The maximum results returned per page.
            /// </summary>
            public const int MaxResultsPerPage = 20;
        }
    }
}
