namespace DAL.Repositories.Competition
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DAL.Contexts;
    using DAL.Entities.Competition;
    using DAL.Repositories.Interfaces;

    public class ResultRepository : GenericRepository<ResultEntity, CompetitionContext>, IResultRepository
    {
        public ResultRepository(CompetitionContext context)
            : base(context)
        {
        }

        public override IEnumerable<ResultEntity> GetAll()
        {
            return this.DbSet
                .AsNoTracking()
                .Include(r => r.PrizeEntityIds)
                .AsEnumerable();
        }

        public override IEnumerable<ResultEntity> Get(Func<ResultEntity, bool> predicate)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(r => r.PrizeEntityIds)
                .AsEnumerable()
                .Where(predicate);
        }

        public IEnumerable<ResultEntity> GetResultsByMark(float begin, float end)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(r => r.PrizeEntityIds)
                .Where(r => r.Mark >= begin && r.Mark <= end)
                .AsEnumerable();
        }

        public IEnumerable<ResultEntity> GetResultsByPrize(PrizeEntity prize)
        {
            return this.DbSet
                .AsNoTracking()
                .Include(r => r.PrizeEntityIds)
                .Where(r => r.PrizeEntityIds.Contains(prize.Id))
                .AsEnumerable();
        }
    }
}