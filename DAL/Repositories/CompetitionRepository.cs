namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class CompetitionRepository : GenericRepository<CompetitionEntity, CompetitionContext>, ICompetitionRepository
    {
        public CompetitionRepository(CompetitionContext context)
            : base(context)
        {
        }

        public CompetitionEntity GetCompetitionById(int id)
        {
            return Context.Competitions.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CompetitionEntity> GetCompetitions(DateTime begin, DateTime end)
        {
            return Context.Competitions.Where(x => x.DateTimeBegin == begin && x.DateTimeEnd == end);
        }

        public IEnumerable<CompetitionEntity> GetCompetitions(string skill)
        {
            return Context.Competitions.Where(x => x.Skill.Name.Equals(skill));
        }

        public void CreateCompetition(SkillEntity skill, DateTime begin, DateTime end, ICollection<StageEntity> stages)
        {
            Context.Competitions.Add(new CompetitionEntity(skill, begin, end, stages));
        }

        public void DeleteCompetition(int id)
        {
            var competition = this.GetCompetitionById(id);
            if (competition != null)
            {
                Context.Competitions.Remove(competition);
            }
        }

        public void UpdateCompetition(int id, DateTime begin, DateTime end, ICollection<StageEntity> stages)
        {
            var competition = this.GetCompetitionById(id);
            if (competition != null)
            {
                competition.DateTimeBegin = begin;
                competition.DateTimeEnd = end;
                competition.Stages.Clear();
                foreach (var stage in stages)
                {
                    competition.Stages.Add(stage);
                }
            }
        }
    }
}