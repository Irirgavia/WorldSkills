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

        IEnumerable<TEntity> GetList(Func<TEntity, bool> predicate);

        TEntity Get(Func<TEntity, bool> predicate);

        void Remove(TEntity item);

        void Update(TEntity item);

        void CreateOrUpdate(TEntity item);
    }
}