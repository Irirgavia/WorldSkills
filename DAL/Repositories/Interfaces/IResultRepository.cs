namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IResultRepository : IGenericRepository<ResultEntity>
    {
        IEnumerable<ResultEntity> GetResultsByMark(float begin, float end);
    }
}