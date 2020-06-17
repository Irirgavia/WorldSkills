namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities.Competition;

    public interface ICompetitionRepository : IGenericRepository<CompetitionEntity>
    {
        IEnumerable<CompetitionEntity> GetCompetitionsForRegistration(string stageTypeName);
    }
}