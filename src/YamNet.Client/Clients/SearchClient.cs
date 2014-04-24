// -----------------------------------------------------------------------
// <copyright file="RelationshipClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Yammer search client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/#rest-search
    /// </remarks>
    public class SearchClient : ClientBase
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
        /// Get all topics in the User's netowrk that match the given search text.
        /// </summary>
        /// <param name="queryText">The text to search within topics.</param>
        /// <param name="page">Only <see cref="numberPerPage"/> results will be returned for each page.  E.g. page = 2 will return items 21 - 30.</param>
        /// <param name="numberPerPage">Limits the number of results per page, up to 20.</param>
        /// <returns></returns>
        public async Task<IQueryable<TopicSearchResult>> Topics(string queryText, int page = 0, int numberPerPage = 0)
        {
            var query = new SearchQuery(queryText, page, numberPerPage);
            var url = GetFinalUrl(string.Format("{0}.json", BaseUri), query.SerializeQueryString());
            var result = await this.Client.GetAsync<SearchEnvelope>(url);

            return result.Content.Topics.AsQueryable();
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
        /// <param name="queryText">The text to search within topics.</param>
        /// <param name="page">Only <see cref="numberPerPage"/> results will be returned for each page.  E.g. page = 2 will return items 21 - 30.</param>
        /// <param name="numberPerPage">Limits the number of results per page, up to 20.</param>
        public SearchQuery(string queryText, int page, int numberPerPage)
        {
            if (page > 1)
            {
                Page = page;
            }

            if (numberPerPage > 1)
            {
                Number_Per_Page = numberPerPage;
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
        public int? Number_Per_Page { get; set; }

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Search { get; set; }
    }
}
