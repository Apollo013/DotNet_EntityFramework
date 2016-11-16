using Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Base
{
    public interface IGenericReadableRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        IEnumerable<TEntity> All();
        TEntity FindByKey(TKey id);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
    }
}
