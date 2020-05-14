namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IResultRepository : IGenericRepository<ResultEntity>
    {
        ResultEntity GetResultById(int id);

        ResultEntity GetResultByIdAnswer(int id);

        IEnumerable<ResultEntity> GetResultsByMark(float begin, float end);

        void CreateResult();

        void CreateResult(
            float mark,
            string notes);

        void DeleteResult(int id);

        void UpdateResult(
            int id,
            float mark,
            string notes);
    }
}