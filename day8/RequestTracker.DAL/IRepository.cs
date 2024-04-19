using System.Collections.Generic;

namespace RequestTrackerDALLibrary
{
    public interface IRepository<TKey, TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Get(TKey id);
        List<TEntity> GetAll();
        void Remove(TKey id);
    }
}
