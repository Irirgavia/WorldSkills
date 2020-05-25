namespace DAL.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class TaskRepository : GenericRepository<TaskEntity, CompetitionContext>, ITaskRepository
    {
        public TaskRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<TaskEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.Addresses)
                .Include(c => c.Answers)
                .AsEnumerable();
        }

        public override IEnumerable<TaskEntity> Get(Func<TaskEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.Addresses)
                .Include(c => c.Answers)
                .AsEnumerable()
                .Where(predicate);
        }
    }
}