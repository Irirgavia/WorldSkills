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
                .Include(c => c.Stages)
                .AsEnumerable();
        }

        public override IEnumerable<CompetitionEntity> Get(Func<CompetitionEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(c => c.Skill)
                .Include(c => c.Stages)
                .AsEnumerable()
                .Where(predicate);
        }
    }
}