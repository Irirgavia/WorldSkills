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

        public ResultEntity GetResultByIdAnswer(int id)
        {
            return Context.Results.AsNoTracking().FirstOrDefault(x => x.Answer.Id == id);
        }

        public IEnumerable<ResultEntity> GetResultsByMark(float begin, float end)
        {
            return Context.Results.AsNoTracking().Where(x => x.Mark >= begin && x.Mark <= end);
        }
    }
}