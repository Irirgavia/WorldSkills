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
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.Tasks.Select(t => t.Addresses))
                .Include(s => s.Tasks.Select(t => t.Answers.Select(a => a.Result)))
                .Include(s => s.Tasks.Select(t => t.Answers.Select(a => a.Participant)))
                .Include(s => s.Administrators.Select(a => a.User))
                .Include(s => s.Judges.Select(a => a.User))
                .Include(s => s.Participants.Select(a => a.User))
                .Include(s => s.Participants.Select(a => a.Address))
                .Where(x => x.CompetitionEntityId == competitionId);
        }

        public override IEnumerable<StageEntity> Get(Func<StageEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.Tasks.Select(t => t.Addresses))
                .Include(s => s.Tasks.Select(t => t.Answers.Select(a => a.Result)))
                .Include(s => s.Tasks.Select(t => t.Answers.Select(a => a.Participant)))
                .Include(s => s.Administrators.Select(a => a.User))
                .Include(s => s.Judges.Select(a => a.User))
                .Include(s => s.Participants.Select(a => a.User))
                .Include(s => s.Participants.Select(a => a.Address))
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<StageEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(s => s.Tasks.Select(t => t.Addresses))
                .Include(s => s.Tasks.Select(t => t.Answers.Select(a => a.Result)))
                .Include(s => s.Tasks.Select(t => t.Answers.Select(a => a.Participant)))
                .Include(s => s.Administrators.Select(a => a.User))
                .Include(s => s.Judges.Select(a => a.User))
                .Include(s => s.Participants.Select(a => a.User))
                .Include(s => s.Participants.Select(a => a.Address))
                .AsEnumerable();
        }
    }
}