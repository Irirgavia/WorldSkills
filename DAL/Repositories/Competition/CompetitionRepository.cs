namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading;

    using DAL.Contexts;
    using DAL.Entities.Competition;
    using DAL.Repositories.Interfaces;

    public class CompetitionRepository : GenericRepository<CompetitionEntity, CompetitionContext>, ICompetitionRepository
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

        public IEnumerable<CompetitionEntity> GetCompetitionsForRegistration(string stageTypeName)
        {
            return from competition in this.Context.Competitions
                    from stage in competition.StageEntities
                    where stage.StageTypeEntity.Name == stageTypeName
                    from task in stage.TaskEntities
                    where task.DateTimeBegin < DateTime.Now
                    select competition;
        }
    }
}