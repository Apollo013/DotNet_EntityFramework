using Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Base
{
    /// <summary>
    /// Generic repository whereby the primary key is an integer
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity, int> where TEntity : BaseEntity<int>
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #region 'IGenericReadableRepository' implementations

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
        #endregion

        #region 'IGenericWriteableRepository' implementations
        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Remove(int id)
        {
            var entity = FindByKey(id);
            _dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        #region 'IGenericReadableIncludingRepository' implementations (Eager Loading)

        /// <summary>
        /// Returns all entities including the data for the specified properties
        /// </summary>
        /// <param name="includedProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includedProperties)
        {
            return GetAllIncluding(includedProperties).ToList();
        }

        /// <summary>
        /// Returns all entities including the data for the specified properties, as specified by the predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includedProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindByIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includedProperties)
        {
            var query = GetAllIncluding(includedProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includedProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includedProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #endregion

        #region Using Lamda Expressions
        /// <summary>
        /// Builds a lamda expression to find an entity by it's primary key
        /// <para>
        /// We could easily switch out the integer data type for another and expect this to still work.
        /// This is simply an alternative to the 'FindByKey' method above.
        /// </para>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity FindKey(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(ExpressionBuilderExtension.BuildLamdaExpressionForKey<TEntity>(id));
        }
        #endregion

        #region Saving
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
