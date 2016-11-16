using Models.Base;

namespace Repositories.Base
{
    public interface IGenericRepository<TEntity, TKey> : IGenericReadableRepository<TEntity, TKey>,
                                                         IGenericWriteableRepository<TEntity, TKey>,
                                                         IGenericReadableIncludingRepository<TEntity>
                                                         where TEntity : BaseEntity<TKey>
    {
        void SaveChanges();
    }
}
