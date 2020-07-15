﻿using CRM.Core;

using System.Collections.Generic;
using System.Linq;

namespace CRM.Data.Interfaces
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(object id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<T> entities);

        /// Create entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Create(T entity);
        
        // Create entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Create(IEnumerable<T> entities);

        // Edit entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Edit(T entity);

        // Edit entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Edit(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        List<T> ExecuteSP(string query, params object[] parameters);


        /// <summary>
        /// Insert  a table with cammand
        /// </summary>
        void ExecuteCammandSP(string query, params object[] parameters);

        
    }
}
