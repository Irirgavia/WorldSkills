namespace DAL.Repositories.Interfaces
{
    using System.CodeDom.Compiler;
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IAnswerRepository : IGenericRepository<AnswerEntity>
    {
        AnswerEntity GetAnswerById(int id);

        IEnumerable<AnswerEntity> GetAnswersByIdTask(int id);

        void CreateAnswer(
            ParticipantEntity participant,
            ResultEntity result,
            TaskEntity task,
            string projectLink,
            string notes);

        void DeleteAnswer(int id);

        void UpdateAnswer(
            int id,
            ParticipantEntity participant,
            ResultEntity result,
            string projectLink,
            string notes);
    }
}