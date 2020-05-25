namespace DAL.Repositories.Interfaces
{
    using System.Collections.Generic;

    using DAL.Entities;

    public interface IStageRepository : IGenericRepository<StageEntity>
    {
        IEnumerable<StageEntity> GetStagesByCompetitionId(int competitionID);
    }
}