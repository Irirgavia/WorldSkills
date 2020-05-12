namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface ITrainerRepository : IGenericRepository<TrainerEntity>
    {
        TrainerEntity GetTrainerById(int id);

        void CreateTrainer(
            UserEntity user,
            ICollection<ParticipantEntity> participants);

        void DeleteTrainer(int id);

        void UpdateTrainer(
            int id,
            UserEntity user,
            ICollection<ParticipantEntity> participants);
    }
}