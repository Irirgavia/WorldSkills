namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class TaskRepository : GenericRepository<TaskEntity, CompetitionContext>
    {
        public TaskRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<TaskEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.AddressEntities)
                .Include(c => c.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))
                .AsEnumerable();
        }

        public override IEnumerable<TaskEntity> Get(Func<TaskEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.AddressEntities)
                .Include(c => c.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))
                .AsEnumerable()
                .Where(predicate);
        }
    }
}