namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IJudgeRepository : IGenericRepository<JudgeEntity>
    {
        JudgeEntity GetJudgeById(int id);

        void CreateJudge(
            UserEntity user, 
            ICollection<StageEntity> stages);

        void DeleteJudge(int id);

        void UpdateJudge(
            int id,
            UserEntity user,
            ICollection<StageEntity> stages);
    }
}