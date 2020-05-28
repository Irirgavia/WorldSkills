namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities;
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
                .Include(c => c.Skill)
                .Include(c => c.Stages.Select(s => s.Tasks.Select(t => t.Addresses)))
                .Include(c => c.Stages.Select(s => s.Tasks.Select(t => t.Answers.Select(a => a.Result))))
                .Include(c => c.Stages.Select(s => s.Tasks.Select(t => t.Answers.Select(a => a.Participant))))
                .AsEnumerable();
        }

        public override IEnumerable<CompetitionEntity> Get(Func<CompetitionEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.Skill)
                .Include(c => c.Stages.Select(s => s.Tasks.Select(t => t.Addresses)))
                .Include(c => c.Stages.Select(s => s.Tasks.Select(t => t.Answers.Select(a => a.Result))))
                .Include(c => c.Stages.Select(s => s.Tasks.Select(t => t.Answers.Select(a => a.Participant))))
                .AsEnumerable()
                .Where(predicate);
        }
    }
}