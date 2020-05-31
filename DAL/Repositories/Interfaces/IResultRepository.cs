namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities.Competition;

    public interface IResultRepository : IGenericRepository<ResultEntity>
    {
        IEnumerable<ResultEntity> GetResultsByMark(float begin, float end);

        IEnumerable<ResultEntity> GetResultsByPrize(PrizeEntity prize);
    }
}