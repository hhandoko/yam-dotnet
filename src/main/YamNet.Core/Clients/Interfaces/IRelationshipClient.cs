// -----------------------------------------------------------------------
// <copyright file="IRelationshipClient.cs" company="YamNet">
//   Copyright (c) 2014 YamNet contributors
// </copyright>
// -----------------------------------------------------------------------

namespace YamNet.Client
{
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
        /// Get other user's relationship by their id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The <see cref="Relationship"/>.</returns>
        Task<Relationship> GetById(long userId);

        /// <summary>
        /// Add a relationship to the current user.
        /// </summary>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task AddCurrent(Relation[] relations);

        /// <summary>
        /// Add a relationship to other user by their id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relations">The relations.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task AddById(long userId, Relation[] relations);

        /// <summary>
        /// Delete a relationship from the current user by the relation's user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="relationshipType">The relationship type.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        Task DeleteById(long userId, RelationshipType relationshipType);
    }
}
