namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class ResultRepository : GenericRepository<ResultEntity, CompetitionContext>, IResultRepository
    {
        public ResultRepository(CompetitionContext context)
            : base(context)
        {
        }

        public IEnumerable<ResultEntity> GetResultsByMark(float begin, float end)
        {
            return this.DbSet
                .AsNoTracking()
                .Where(x => x.Mark >= begin && x.Mark <= end)
                .AsEnumerable();
        }
    }
}