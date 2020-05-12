namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IStageRepository : IGenericRepository<StageEntity>
    {
        StageEntity GetStageById(int id);

        IEnumerable<StageEntity> GetStagesByCompetition(CompetitionEntity competition);

        void CreateStage(
            CompetitionEntity competition,
            TypeStage typeStage,
            ICollection<TaskEntity> tasks,
            ICollection<ParticipantEntity> participant,
            ICollection<JudgeEntity> judges,
            ICollection<AdministratorEntity> administrators);

        void DeleteStage(int id);

        void UpdateStage(
            int id, 
            ICollection<TaskEntity> tasks,
            ICollection<ParticipantEntity> participant,
            ICollection<JudgeEntity> judges,
            ICollection<AdministratorEntity> administrators);
    }
}