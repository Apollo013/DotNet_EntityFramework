using Models.Base;

namespace Repositories.Base
{
    public interface IGenericWriteableRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(TKey id);
    }
}
