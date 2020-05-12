namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity item);

        TEntity FindById(int id);

        IEnumerable<TEntity> GetAll();

        void Remove(TEntity item);

        void Update(TEntity item);

        int CreateOrUpdate(TEntity entity, Func<TEntity, bool> predicate);
    }
}