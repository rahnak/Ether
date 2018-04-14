using System.Collections.Generic;

namespace Ether.Data.Interfaces
{
    public interface IDataAccess<T> where T : IEntity
    {
        /// <summary>
        /// Get all entities.
        /// </summary>
        /// <returns>Returns an IEnumerable with the entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get an entity by Id.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>The entity (can be null)</returns>
        T GetById(int id);

        /// <summary>
        /// Create a new entity.
        /// </summary>
        /// <param name="entity">The entity to create</param>
        /// <returns>Returns the entity's id</returns>
        int Create(T entity);

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns>Returns true on success, false otherwise</returns>
        bool Update(T entity);

        /// <summary>
        /// Delete an existing entity.
        /// </summary>
        /// <param name="id">The id of the entity</param>
        /// <returns>Returns true on success, false otherwise</returns>
        bool Delete(int id);
    }
}