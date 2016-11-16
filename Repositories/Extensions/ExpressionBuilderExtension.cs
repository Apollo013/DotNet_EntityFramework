using System;
using System.Linq.Expressions;

namespace Repositories
{
    public static class ExpressionBuilderExtension
    {
        /// <summary>
        /// Builds a lamda expression to find an entity by it's primary key
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Expression<Func<TEntity, bool>> BuildLamdaExpressionForKey<TEntity>(int id)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, "Id"); // Assuming 'Id' is the name of the primary key that we are looking for
            var value = Expression.Constant(id);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
    }
}
