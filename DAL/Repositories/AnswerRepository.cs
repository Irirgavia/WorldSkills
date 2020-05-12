namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class AnswerRepository : GenericRepository<AnswerEntity, CompetitionContext>, IAnswerRepository
    {
        public AnswerRepository(CompetitionContext context)
            : base(context)
        {
        }

        public AnswerEntity GetAnswerById(int id)
        {
            return Context.Answers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AnswerEntity> GetAnswersByIdTask(int id)
        {
            var task = Context.Tasks.FirstOrDefault(x => x.Id == id);
            return Context.Answers.Where(X => X.Task == task);
        }

        public void CreateAnswer(
            ParticipantEntity participant,
            ResultEntity result,
            TaskEntity task,
            string projectLink,
            string notes)
        {
            Context.Answers.Add(new AnswerEntity(participant, result, task, projectLink, notes));
        }

        public void DeleteAnswer(int id)
        {
            var answer = this.GetAnswerById(id);
            if (answer != null)
            {
                Context.Answers.Remove(answer);
            }
        }

        public void UpdateAnswer(
            int id,
            ParticipantEntity participant,
            ResultEntity result,
            string projectLink,
            string notes)
        {
            var answer = this.GetAnswerById(id);
            if (answer != null)
            {
                answer.Participant = participant;
                answer.Result = result;
                answer.ProjectLink = projectLink;
                answer.Notes = notes;
            }
        }
    }
}