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

        public ResultEntity GetResultById(int id)
        {
            return Context.Results.FirstOrDefault(x => x.Id == id);
        }

        public ResultEntity GetResultByIdAnswer(int id)
        {
            return Context.Results.FirstOrDefault(x => x.Answer.Id == id);
        }

        public IEnumerable<ResultEntity> GetResultsByMark(float begin, float end)
        {
            return Context.Results.Where(x => x.Mark >= begin && x.Mark <= end);
        }

        public void CreateResult()
        {
            Context.Results.Add(new ResultEntity());
        }

        public void CreateResult(float mark, string notes)
        {
            Context.Results.Add(new ResultEntity(mark, notes));
        }

        public void DeleteResult(int id)
        {
            var result = this.GetResultById(id);
            if (result != null)
            {
                Context.Results.Remove(result);
            }
        }

        public void UpdateResult(int id, float mark, string notes)
        {
            var result = this.GetResultById(id);
            if (result != null)
            {
                result.Mark = mark;
                result.Notes = notes;
            }
        }
    }
}