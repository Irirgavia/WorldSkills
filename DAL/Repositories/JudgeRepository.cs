namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class JudgeRepository : GenericRepository<JudgeEntity, CompetitionContext>, IJudgeRepository
    {
        public JudgeRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<JudgeEntity> Get(Func<JudgeEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(a => a.User)
                .AsEnumerable()
                .Where(predicate);
        }

        public override IEnumerable<JudgeEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .AsEnumerable();
        }
    }
}