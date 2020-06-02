namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        TEntity Create(TEntity item);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void Remove(TEntity item);

        void Update(TEntity item);

        void CreateOrUpdate(TEntity item);

        TEntity GetOrCreate(TEntity item, Func<TEntity, bool> predicate);
    }
}