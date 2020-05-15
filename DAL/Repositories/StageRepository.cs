namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class StageRepository : GenericRepository<StageEntity, CompetitionContext>, IStageRepository
    {
        public StageRepository(CompetitionContext context)
            : base(context)
        {
        }

        public IEnumerable<StageEntity> GetStagesByCompetition(CompetitionEntity competition)
        {
            return Context.Stages.AsNoTracking().Where(x => x.Competition == competition);
        }
    }
}