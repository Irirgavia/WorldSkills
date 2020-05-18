namespace DAL.Repositories.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }

        IAdministratorRepository AdministratorRepository { get; }

        IAnswerRepository AnswerRepository { get; }

        ICompetitionRepository CompetitionRepository { get; }

        IJudgeRepository JudgeRepository { get; }

        IParticipantRepository ParticipantRepository { get; }

        IResultRepository ResultRepository { get; }

        ISkillRepository SkillRepository { get; }

        IStageRepository StageRepository { get; }

        ITaskRepository TaskRepository { get; }
        
        ITrainerRepository TrainerRepository { get; }

        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
}