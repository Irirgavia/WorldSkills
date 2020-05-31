namespace DAL.UnitOfWorks.Interfaces
{
    using DAL.Entities.Competition;
    using DAL.Repositories.Interfaces;

    public interface ICompetitionUnitOfWorks : IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }

        IGenericRepository<AnswerEntity> AnswerRepository { get; }

        IGenericRepository<CompetitionEntity> CompetitionRepository { get; }

        IGenericRepository<PrizeEntity> PrizeRepository { get; }

        IResultRepository ResultRepository { get; }

        IGenericRepository<SkillEntity> SkillRepository { get; }

        IGenericRepository<StageEntity> StageRepository { get; }

        IGenericRepository<StageTypeEntity> StageTypeRepository { get; }

        IGenericRepository<TaskEntity> TaskRepository { get; }
    }
}