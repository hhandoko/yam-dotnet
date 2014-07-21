// -----------------------------------------------------------------------
// <copyright file="IRelationshipClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The RelationshipClient interface.
    /// </summary>
    public interface IRelationshipClient
    {
        /// <summary>
        /// Get current user's relationship.
        /// </summary>
        /// <returns>The <see cref="Relationship"/>.</returns>
        Task<Relationship> GetCurrent();

        /// <summary>
        /// Get the user's relationship given the id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The <see cref="Relationship"/>.</returns>
        Task<Relationship> GetById(long userId);

        /// <summary>
        /// Add a relationship to the current user.
        /// </summary>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task AddCurrent(Dictionary<string, RelationshipType> relations);

        /// <summary>
        /// Add a relationship by the user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task AddById(long userId, Dictionary<string, RelationshipType> relations);

        /// <summary>
        /// Delete a relationship by the relation's user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relationshipType">The relationship type.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteById(long userId, RelationshipType relationshipType);
    }
}
