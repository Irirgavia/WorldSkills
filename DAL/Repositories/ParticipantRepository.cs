namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class ParticipantRepository : GenericRepository<ParticipantEntity, CompetitionContext>, IParticipantRepository
    {
        public ParticipantRepository(CompetitionContext context)
            : base(context)
        {
        }

        public ParticipantEntity GetParticipantById(int id)
        {
            return Context.Participants.FirstOrDefault(x => x.Id == id);
        }

        public void CreateParticipant(
            UserEntity user,
            TrainerEntity trainer,
            AddressEntity address,
            ICollection<AnswerEntity> answers,
            ICollection<StageEntity> stages)
        {
            Context.Participants.Add(new ParticipantEntity(user, trainer, address, answers, stages));
        }

        public void DeleteParticipant(int id)
        {
            var participant = this.GetParticipantById(id);
            if (participant != null)
            {
                Context.Participants.Remove(participant);
            }
        }

        public void UpdateParticipant(
            int id,
            UserEntity user,
            TrainerEntity trainer,
            AddressEntity address,
            ICollection<AnswerEntity> answers,
            ICollection<StageEntity> stages)
        {
            var participant = this.GetParticipantById(id);
            if (participant != null)
            {
                participant.User = user;
                participant.Trainer = trainer;
                participant.Address = address;
                participant.Answers.Clear();
                foreach (var answer in answers)
                {
                    participant.Answers.Add(answer);
                }

                participant.Stages.Clear();
                foreach (var stage in stages)
                {
                    participant.Stages.Add(stage);
                }
            }
        }
    }
}