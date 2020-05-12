namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class TrainerRepository : GenericRepository<TrainerEntity,CompetitionContext>, ITrainerRepository
    {
        public TrainerRepository(CompetitionContext context)
            : base(context)
        {
        }

        public TrainerEntity GetTrainerById(int id)
        {
            return Context.Trainers.FirstOrDefault(x => x.Id == id);
        }

        public void CreateTrainer(UserEntity user, ICollection<ParticipantEntity> participants)
        {
            Context.Trainers.Add(new TrainerEntity(user, participants));
        }

        public void DeleteTrainer(int id)
        {
            var trainer = this.GetTrainerById(id);
            if (trainer != null)
            {
                Context.Trainers.Add(trainer);
            }
        }

        public void UpdateTrainer(int id, UserEntity user, ICollection<ParticipantEntity> participants)
        {
            var trainer = this.GetTrainerById(id);
            if (trainer != null)
            {
                trainer.User = user;
                trainer.Participants.Clear();
                foreach (var participant in participants)
                {
                    trainer.Participants.Add(participant);
                }
            }
        }
    }
}