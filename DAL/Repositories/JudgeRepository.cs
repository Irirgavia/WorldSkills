namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class JudgeRepository : GenericRepository<JudgeEntity, CompetitionContext>, IJudgeRepository
    {
        public JudgeRepository(CompetitionContext context)
            : base(context)
        {
        }

        public JudgeEntity GetJudgeById(int id)
        {
            return Context.Judges.FirstOrDefault(x => x.Id == id);
        }

        public void CreateJudge(UserEntity user, ICollection<StageEntity> stages)
        {
            Context.Judges.Add(new JudgeEntity(user, stages));
        }

        public void DeleteJudge(int id)
        {
            var judge = this.GetJudgeById(id);
            if (judge != null)
            {
                Context.Judges.Remove(judge);
            }
        }

        public void UpdateJudge(int id, UserEntity user, ICollection<StageEntity> stages)
        {
            var judge = this.GetJudgeById(id);
            if (judge != null)
            {
                judge.User = user;
                judge.Stages.Clear();
                foreach (var stage in stages)
                {
                    judge.Stages.Add(stage);
                }
            }
        }
    }
}