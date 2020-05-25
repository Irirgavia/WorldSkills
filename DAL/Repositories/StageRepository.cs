namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class StageRepository : GenericRepository<StageEntity, CompetitionContext>, IStageRepository
    {
        public StageRepository(CompetitionContext context)
            : base(context)
        {
        }

        public IEnumerable<StageEntity> GetStagesByCompetitionId(int competitionId)
        {
            return this.DbSet.AsNoTracking().Where(x => x.CompetitionEntityId == competitionId);
        }

        public override IEnumerable<StageEntity> Get(Func<StageEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.Tasks)
                .Include(s => s.Administrators)
                .Include(s => s.Judges)
                .Include(s => s.Participants)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<StageEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.Tasks)
                .Include(s => s.Administrators)
                .Include(s => s.Judges)
                .Include(s => s.Participants)
                .AsEnumerable();
        }
    }
}