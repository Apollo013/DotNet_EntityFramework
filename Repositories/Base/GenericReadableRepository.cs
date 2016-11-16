using Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Base
{
    public abstract class GenericReadableRepository<TEntity> : IGenericReadableRepository<TEntity, int> where TEntity : BaseEntity<int>
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        protected GenericReadableRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity FindByKey(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }
    }
}
