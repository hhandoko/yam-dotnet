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
    /// Yammer user's relationship / org chart client.
    /// Manipulate the Yammer Org Chart.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/
    /// </remarks>
    public class RelationshipClient : ClientBase, IRelationshipClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public RelationshipClient(Client client) : base(client)
        {
        }

        /// <summary>
        /// Get current user's relationship.
        /// </summary>
        /// <returns>The <see cref="RelationshipEnvelope"/>.</returns>
        public async Task<RelationshipEnvelope> GetCurrent()
        {
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Relationships));
            var result = await this.Client.GetAsync<RelationshipEnvelope>(url);

            return result.Content;
        }

        /// <summary>
        /// Get other user's relationship by their id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The <see cref="RelationshipEnvelope"/>.</returns>
        public async Task<RelationshipEnvelope> GetById(long userId)
        {
            var query = new RelationshipQuery(userId, null);
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Relationships), query.SerializeQueryString());
            var result = await this.Client.GetAsync<RelationshipEnvelope>(url);

            return result.Content;
        }

        /// <summary>
        /// Add a relationship to the current user.
        /// </summary>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddCurrent(Relation[] relations)
        {
            var query = GetRelationsQueryParams(null, relations);
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Relationships), query);

            await this.Client.PostAsync(url);
        }

        /// <summary>
        /// Add a relationship to other user by their id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task AddById(long userId, Relation[] relations)
        {
            var query = GetRelationsQueryParams(userId, relations);
            var url = this.GetFinalUrl(string.Format("{0}.json", Endpoints.Relationships), query);
            
            await this.Client.PostAsync(url);
        }

        /// <summary>
        /// Delete a relationship from the current user by the relation's user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relationshipType">The relationship type.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task DeleteById(long userId, RelationshipType relationshipType)
        {
            var query = new RelationshipQuery(null, relationshipType);
            var url = this.GetFinalUrl(string.Format("{0}/{1}.json", Endpoints.Relationships, userId), query.SerializeQueryString());

            await this.Client.DeleteAsync(url);
        }

        /// <summary>
        /// Get the relations query params.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetRelationsQueryParams(long? userId, Relation[] relations)
        {
            var queryParams = string.Empty;
            
            var relationsStringArray = relations.Select(x => string.Format("{0}={1}", x.Relationship.ToString().ToLowerInvariant(), x.UserId)).ToArray();
            var relationsQueryParams = string.Join("&", relationsStringArray);

            if (userId != null)
            {
                queryParams = string.Format(
                    "{0}&{1}",
                    new RelationshipQuery(userId, null).SerializeQueryString(),
                    relationsQueryParams);
            }
            else
            {
                queryParams = relationsQueryParams;
            }

            return queryParams;
        }
    }

    /// <summary>
    /// The relationship query.
    /// </summary>
    internal class RelationshipQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipQuery"/> class.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relationship">The relationship type.</param>
        public RelationshipQuery(
            long? userId,
            RelationshipType? relationship)
        {
            if (userId != null)
            {
                this.User_Id = userId;
            }

            if (relationship != null)
            {
                this.Type = relationship;
            }
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public long? User_Id { get; set; }

        /// <summary>
        /// Gets or sets the relationship type.
        /// </summary>
        public RelationshipType? Type { get; set; }
    }

    /// <summary>
    /// The user's relation.
    /// </summary>
    public class Relation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Relation"/> class.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relationship">The relationship type.</param>
        public Relation(long userId, RelationshipType relationship)
        {
            this.UserId = userId;
            this.Relationship = relationship;
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the relationship type.
        /// </summary>
        public RelationshipType Relationship { get; set; }
    }

    /// <summary>
    /// The org chart relationship type.
    /// </summary>
    public enum RelationshipType
    {
        /// <summary>
        /// Indicates the user's superior.
        /// </summary>
        Superior,

        /// <summary>
        /// Indicates the user's colleague.
        /// </summary>
        Colleague,

        /// <summary>
        /// Indicates the user's subordinate.
        /// </summary>
        Subordinate
    }

    /// <summary>
    /// The REST API endpoints.
    /// </summary>
    internal partial class Endpoints
    {
        /// <summary>
        /// Relationships endpoint.
        /// </summary>
        public const string Relationships = "/relationships";
    }
}
