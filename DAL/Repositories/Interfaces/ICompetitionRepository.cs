namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DAL.Entities;

    public interface ICompetitionRepository : IGenericRepository<CompetitionEntity>
    {
        IEnumerable<CompetitionEntity> GetActualCompetitions(DateTime currenTime);

        IEnumerable<CompetitionEntity> GetCompetitions(
            DateTime begin, 
            DateTime end);

        IEnumerable<CompetitionEntity> GetCompetitionsBySkill(string skill);
    }
}