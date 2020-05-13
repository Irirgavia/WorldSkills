namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DAL.Entities;

    public interface ICompetitionRepository : IGenericRepository<CompetitionEntity>
    {
        CompetitionEntity GetCompetitionById(int id);

        IEnumerable<CompetitionEntity> GetCompetitions(
            DateTime begin, 
            DateTime end);

        IEnumerable<CompetitionEntity> GetCompetitions(string skill);

        void CreateCompetition(
            SkillEntity skill,
            DateTime begin,
            DateTime end, 
            ICollection<StageEntity> stages);

        void DeleteCompetition(int id);

        void UpdateCompetition(
            int id,
            DateTime begin,
            DateTime end,
            ICollection<StageEntity> stages);
    }
}