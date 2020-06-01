namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class StageRepository : GenericRepository<StageEntity, CompetitionContext>
    {
        public StageRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<StageEntity> Get(Func<StageEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.TaskEntities.Select(t => t.AddressEntities))
                .Include(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntityIds)))
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<StageEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.TaskEntities.Select(t => t.AddressEntities))
                .Include(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntityIds)))
                .AsEnumerable();
        }
    }
}