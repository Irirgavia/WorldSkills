namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class StageRepository : GenericRepository<StageEntity, CompetitionContext>, IStageRepository
    {
        public StageRepository(CompetitionContext context)
            : base(context)
        {
        }

        public StageEntity GetStageById(int id)
        {
            return Context.Stages.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<StageEntity> GetStagesByCompetition(CompetitionEntity competition)
        {
            return Context.Stages.Where(x => x.Competition == competition);
        }

        public void CreateStage(
            CompetitionEntity competition,
            TypeStage typeStage,
            ICollection<TaskEntity> tasks,
            ICollection<ParticipantEntity> participant,
            ICollection<JudgeEntity> judges,
            ICollection<AdministratorEntity> administrators)
        {
            Context.Stages.Add(new StageEntity(competition, typeStage, tasks, participant, judges, administrators));
        }

        public void DeleteStage(int id)
        {
            var stage = this.GetStageById(id);
            if (stage != null)
            {
                Context.Stages.Remove(stage);
            }
        }

        public void UpdateStage(
            int id,
            ICollection<TaskEntity> tasks,
            ICollection<ParticipantEntity> participants,
            ICollection<JudgeEntity> judges,
            ICollection<AdministratorEntity> administrators)
        {
            var stage = this.GetStageById(id);
            if (stage != null)
            {
                stage.Tasks.Clear();
                foreach (var task in tasks)
                {
                    stage.Tasks.Add(task);
                }

                stage.Participants.Clear();
                foreach (var participant in participants)
                {
                    stage.Participants.Add(participant);
                }

                stage.Judges.Clear();
                foreach (var judge in judges)
                {
                    stage.Judges.Add(judge);
                }

                stage.Administrators.Clear();
                foreach (var administrator in administrators)
                {
                    stage.Administrators.Add(administrator);
                }
            }
        }
    }
}