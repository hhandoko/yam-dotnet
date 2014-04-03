// -----------------------------------------------------------------------
// <copyright file="RelationshipClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client.Clients
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Yammer user's relationship / org chart client.
    /// </summary>
    /// <remarks>
    /// REST API documentation: https://developer.yammer.com/restapi/
    /// </remarks>
    public class RelationshipClient : ClientBase, IRelationshipClient
    {
        /// <summary>
        /// The user relationship base uri.
        /// </summary>
        private const string BaseUri = "/relationships";

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationshipClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public RelationshipClient(Client client)
            : base(client)
        {
        }

        /// <summary>
        /// Get current user's relationship.
        /// </summary>
        /// <returns>The <see cref="Relationship"/>.</returns>
        public Relationship GetCurrent()
        {
            var query = new RelationshipQuery(null, null);
            var url = this.GetFinalUrl(string.Format("{0}.json", BaseUri), query.SerializeQueryString());

            return this.Client.GetAsync<Relationship>(url).Result.Content;
        }

        /// <summary>
        /// Get the user's relationship given the id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The <see cref="Relationship"/>.</returns>
        public Relationship GetById(long userId)
        {
            var query = new RelationshipQuery(userId, null);
            var url = this.GetFinalUrl(string.Format("{0}.json", BaseUri), query.SerializeQueryString());

            return this.Client.GetAsync<Relationship>(url).Result.Content;
        }

        /// <summary>
        /// Add a relationship to the current user.
        /// </summary>
        /// <param name="relations">The relations.</param>
        public void AddCurrent(Dictionary<string, RelationshipType> relations)
        {
            var query = this.GetRelationsQueryParams(null, relations);
            var url = this.GetFinalUrl(string.Format("{0}.json", BaseUri), query);

            this.Client.PostAsync(url);
        }

        /// <summary>
        /// Add a relationship by the user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relations">The relations.</param>
        public void AddById(long userId, Dictionary<string, RelationshipType> relations)
        {
            var query = this.GetRelationsQueryParams(userId, relations);
            var url = this.GetFinalUrl(string.Format("{0}.json", BaseUri), query);
            
            this.Client.PostAsync(url);
        }

        /// <summary>
        /// Delete a relationship by the relation's user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relationshipType">The relationship type.</param>
        public void DeleteById(long userId, RelationshipType relationshipType)
        {
            var query = new RelationshipQuery(null, relationshipType);
            var url = this.GetFinalUrl(string.Format("{0}/{1}.json", BaseUri, userId), query.SerializeQueryString());

            this.Client.DeleteAsync(url);
        }

        /// <summary>
        /// Get the relations query params.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string GetRelationsQueryParams(long? userId, Dictionary<string, RelationshipType> relations)
        {
            var queryParams = string.Empty;
            
            var relationsKeyValue = relations.Select(x => string.Format("{0}={1}", x.Value.ToString().ToLowerInvariant(), x.Key)).ToArray();
            var relationsQueryParams = string.Join("&", relationsKeyValue);

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
        /// <param name="type">The relationship type.</param>
        public RelationshipQuery(
            long? userId,
            RelationshipType? type)
        {
            if (userId != null)
            {
                this.User_Id = userId;
            }

            if (type != null)
            {
                this.Type = type;
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
}
