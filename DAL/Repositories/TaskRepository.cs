namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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
                .Include(c => c.Answers.Select(a => a.Participant.User))
                .Include(c => c.Answers.Select(a => a.Participant.Address))
                .Include(c => c.Answers.Select(a => a.Result))
                .AsEnumerable();
        }

        public override IEnumerable<TaskEntity> Get(Func<TaskEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.Addresses)
                .Include(c => c.Answers.Select(a => a.Participant.User))
                .Include(c => c.Answers.Select(a => a.Participant.Address))
                .Include(c => c.Answers.Select(a => a.Result))
                .AsEnumerable()
                .Where(predicate);
        }
    }
}