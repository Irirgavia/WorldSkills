namespace DAL.Repositories
{
    using System;

    using DAL.Repositories.Interfaces;

    public class UnitOfWork : IDisposable
    {
        private CompetitionContext context;

        public UnitOfWork()
        {
            this.context = new CompetitionContext();
        }

        public IAddressRepository AddressRepository => new AddressRepository(context);

        public IAdministratorRepository AdministratorRepository => new AdministratorRepository(context);

        public IAnswerRepository AnswerRepository => new AnswerRepository(context);

        public ICompetitionRepository CompetitionRepository => new CompetitionRepository(context);

        public IJudgeRepository JudgeRepository => new JudgeRepository(context);

        public IParticipantRepository ParticipantRepository => new ParticipantRepository(context);

        public IResultRepository ResultRepository => new ResultRepository(context);

        public ISkillRepository SkillRepository => new SkillRepository(context);

        public IStageRepository StageRepository => new StageRepository(context);

        public ITaskRepository TaskRepository => new TaskRepository(context);

        public ITrainerRepository TrainerRepository => new TrainerRepository(context);

        public IUserRepository UserRepository => new UserRepository(context);

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                context?.Dispose();
            }
        }
    }
}