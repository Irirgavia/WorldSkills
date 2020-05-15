namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IResultRepository : IGenericRepository<ResultEntity>
    {
        ResultEntity GetResultByIdAnswer(int id);

        IEnumerable<ResultEntity> GetResultsByMark(float begin, float end);
    }
}