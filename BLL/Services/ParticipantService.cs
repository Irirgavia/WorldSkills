namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;
    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Entities.Account;
    using DAL.Entities.Competition;
    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    public sealed class ParticipantService : IParticipantService
    {
        private readonly IAccountUnitOfWork accountUnitOfWork;

        private readonly ICompetitionUnitOfWork competitionUnitOfWork;

        public ParticipantService(string connection)
        {
            this.competitionUnitOfWork = new CompetitionUnitOfWork(connection);
            this.accountUnitOfWork = new AccountUnitOfWork(connection);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public AnswerDTO GetAccountAnswers(int accountId)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.Map(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.AccountEntityId == accountId).FirstOrDefault());
        }

        public IEnumerable<StageDTO> GetStages(int accountId)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(s => s.AccountIds.Contains(accountId)));
        }

        public void RegisterAccountOnCompetitionStage(int competitionId, string stageType, int accountId)
        {
            var stage = this.competitionUnitOfWork.StageRepository.Get(
                                s => s.CompetitionEntityId == competitionId && s.StageTypeEntity.Name == stageType)
                            .FirstOrDefault();
            stage.AccountIds.Add(accountId);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateAccount(AccountDTO account)
        {
            this.accountUnitOfWork.AccountRepository.Update(ObjectMapper<AccountDTO, AccountEntity>.Map(account));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateAnswer(AccountDTO account, int taskId, string notes)
        {
            var answer = this.competitionUnitOfWork.AnswerRepository.Get(
                a => a.TaskEntityId == taskId && a.AccountEntityId == account.Id).FirstOrDefault();

            answer.Notes = notes;
            this.competitionUnitOfWork.AnswerRepository.Update(answer);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateLoginAndPassword(int credentialsId, string login, string password)
        {
            var credentials = this.accountUnitOfWork.CredentialsRepository.GetById(credentialsId);
            credentials.Login = login;
            credentials.Password = PasswordHasher.Hash(password);
            this.accountUnitOfWork.CredentialsRepository.Update(credentials);
            this.accountUnitOfWork.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.competitionUnitOfWork?.Dispose();
                this.accountUnitOfWork?.Dispose();
            }
        }
    }
}