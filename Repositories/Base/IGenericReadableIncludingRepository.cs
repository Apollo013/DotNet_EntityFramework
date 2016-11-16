using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Base
{
    /// <summary>
    /// Generic repository interface for when we want to eager load properties
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericReadableIncludingRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includedProperties);
        IEnumerable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includedProperties);
    }
}
