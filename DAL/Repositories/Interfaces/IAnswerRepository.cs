namespace DAL.Repositories.Interfaces
{
    using System.CodeDom.Compiler;
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IAnswerRepository : IGenericRepository<AnswerEntity>
    {
        IEnumerable<AnswerEntity> GetAnswersByIdTask(int id);
    }
}