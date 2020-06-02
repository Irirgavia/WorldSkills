namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;

    public class CompetitionRepository : GenericRepository<CompetitionEntity, CompetitionContext>
    {
        public CompetitionRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<CompetitionEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.SkillEntity)
                .Include(c => c.StageEntities.Select(s => s.StageTypeEntity))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))))
                .AsEnumerable();
        }

        public override IEnumerable<CompetitionEntity> Get(Func<CompetitionEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.SkillEntity)
                .Include(c => c.StageEntities.Select(s => s.StageTypeEntity))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AddressEntities)))
                .Include(c => c.StageEntities.Select(s => s.TaskEntities.Select(t => t.AnswerEntities.Select(a => a.ResultEntity.PrizeEntity))))
                .AsEnumerable()
                .Where(predicate);
        }
    }
}