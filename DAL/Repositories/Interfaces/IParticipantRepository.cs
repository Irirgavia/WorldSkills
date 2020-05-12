namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IParticipantRepository : IGenericRepository<ParticipantEntity>
    {
        ParticipantEntity GetParticipantById(int id);

        void CreateParticipant(
            UserEntity user,
            TrainerEntity trainer,
            AddressEntity address,
            ICollection<AnswerEntity> answers,
            ICollection<StageEntity> stages);

        void DeleteParticipant(int id);

        void UpdateParticipant(
            int id,
            UserEntity user,
            TrainerEntity trainer,
            AddressEntity address,
            ICollection<AnswerEntity> answers,
            ICollection<StageEntity> stages);
    }
}