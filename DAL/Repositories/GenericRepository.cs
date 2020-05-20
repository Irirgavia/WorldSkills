namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public GenericRepository(TContext context)
        {
            Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; }

        protected TContext Context { get; }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet.AsNoTracking().ToList();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return this.DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return this.DbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            this.DbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public void Remove(TEntity item)
        {
            Context.Entry(item).State = EntityState.Deleted;
        }

        public void CreateOrUpdate(TEntity item)
        {
            Context.Entry(item).State = ((IIdentifier)item).Id == 0 ?
                                            EntityState.Added : 
                                            EntityState.Modified;
        }
    }
}