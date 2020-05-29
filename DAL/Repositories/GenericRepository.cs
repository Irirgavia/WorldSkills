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

        public TEntity Create(TEntity item)
        {
            return this.DbSet.Add(item);
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
            switch (((IIdentifier)item).Id)
            {
                case 0:
                    {
                        this.Create(item);
                        break;
                    }

                default:
                    {
                        Update(item);
                        break;
                    }
            } 
        }

        public TEntity GetOrCreate(TEntity item, Func<TEntity, bool> predicate)
        {
            var entity = this.Get(predicate).FirstOrDefault();
            if (entity == null)
            {
                entity = this.Create(item);
            }

            return entity;
        }
    }
}