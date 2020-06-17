namespace DAL.UnitOfWorks
{
    using System;

    using DAL.Contexts;
    using DAL.Entities.Competition;
    using DAL.Repositories;
    using DAL.Repositories.Competition;
    using DAL.Repositories.Interfaces;
    using DAL.UnitOfWorks.Interfaces;

    public class CompetitionUnitOfWork : ICompetitionUnitOfWork
    {
        private readonly CompetitionContext competitionContext;

        public CompetitionUnitOfWork(string connectionString)
        {
            this.competitionContext = new CompetitionContext(connectionString);
        }

        public IAddressRepository AddressRepository => 
            new CompetitionAddressRepository(this.competitionContext);

        public IGenericRepository<AnswerEntity> AnswerRepository => 
            new AnswerRepository(this.competitionContext);

        public ICompetitionRepository CompetitionRepository =>
            new CompetitionRepository(this.competitionContext);

        public IGenericRepository<PrizeEntity> PrizeRepository =>
            new GenericRepository<PrizeEntity, CompetitionContext>(this.competitionContext);

        public IResultRepository ResultRepository =>
            new ResultRepository(this.competitionContext);

        public IGenericRepository<SkillEntity> SkillRepository =>
            new GenericRepository<SkillEntity, CompetitionContext>(this.competitionContext);

        public IGenericRepository<StageEntity> StageRepository =>
            new StageRepository(this.competitionContext);

        public IGenericRepository<StageTypeEntity> StageTypeRepository =>
            new GenericRepository<StageTypeEntity, CompetitionContext>(this.competitionContext);

        public IGenericRepository<TaskEntity> TaskRepository =>
            new TaskRepository(this.competitionContext);

        public void SaveChanges()
        {
            this.competitionContext.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.competitionContext?.Dispose();
            }
        }
    }
}