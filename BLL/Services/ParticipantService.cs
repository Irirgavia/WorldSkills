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
        private readonly ICompetitionUnitOfWork competitionUnitOfWork;

        private readonly IAccountUnitOfWork accountUnitOfWork;

        public ParticipantService(string connection)
        {
            this.competitionUnitOfWork = new CompetitionUnitOfWork(connection);
            this.accountUnitOfWork = new AccountUnitOfWork(connection);
        }

        // TODO: function
        public void RegisterAccountOnCompetition(int competitionId, StageTypeDTO stageType, int accountId)
        {
            var competition = this.competitionUnitOfWork.CompetitionRepository.Get(c => c.Id == competitionId)
                                  .FirstOrDefault();
            var stage = competition.StageEntities.FirstOrDefault(s => s.StageTypeEntity.Name == stageType.Name);
            var account = this.accountUnitOfWork.AccountRepository.Get(x => x.Id == accountId).FirstOrDefault();
            //stage.AccountIds.Add(account);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateAccount(AccountDTO account)
        {
            this.accountUnitOfWork.AccountRepository.Update(ObjectMapper<AccountDTO, AccountEntity>.Map(account));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateLoginAndPassword(AccountDTO account, string login, string password)
        {
            var credentials = this.accountUnitOfWork.CredentialsRepository.GetById(account.Credentials.Id);
            credentials.Login = login;
            credentials.Password = PasswordHasher.Hash(password);
            this.accountUnitOfWork.CredentialsRepository.Update(credentials);
            this.accountUnitOfWork.CredentialsRepository.Update(credentials);
            this.accountUnitOfWork.SaveChanges();
        }

        // TODO: function
        public IEnumerable<StageDTO> GetStages(AccountDTO account)
        {
            return null; /*ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(
                    s => s.AccountIds.Contains(ObjectMapper<AccountDTO, AccountEntityId>.Map(account))));*/
        }

        // TODO: function
        public AnswerDTO GetParticipantAnswer(AccountDTO account)
        {
            return null; /*ObjectMapper<AnswerEntity, AnswerDTO>.Map(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.AccountEntityId.Id == account.Id)
                    .FirstOrDefault());*/
        }

        public void UpdateAnswer(AccountDTO account, int taskId, string notes)
        {
            var answer = this.competitionUnitOfWork.AnswerRepository.Get(a => a.AccountEntityId == account.Id)
                             .FirstOrDefault();

            answer.Notes = notes;
            this.competitionUnitOfWork.AnswerRepository.Update(answer);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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