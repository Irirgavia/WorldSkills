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

        public IEnumerable<CompetitionEntity> GetActualCompetitions(DateTime currentTime)
        {
            return Context.Competitions.AsNoTracking().Where(x => x.DateTimeEnd >= currentTime);
        }

        public IEnumerable<CompetitionEntity> GetCompetitions(DateTime begin, DateTime end)
        {
            return Context.Competitions.AsNoTracking().Where(x => x.DateTimeBegin >= begin && x.DateTimeEnd <= end);
        }

        public IEnumerable<CompetitionEntity> GetCompetitionsBySkill(string skill)
        {
            return Context.Competitions.AsNoTracking().Where(x => x.Skill.Name.Equals(skill));
        }
    }
}