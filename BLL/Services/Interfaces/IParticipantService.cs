namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;

    public interface IParticipantService : IDisposable
    {
        AnswerDTO GetAccountAnswers(int accountId);

        IEnumerable<StageDTO> GetStages(int accountId);

        void RegisterAccountOnCompetitionStage(int competitionId, string stageType, int accountId);

        void UpdateAccount(AccountDTO account);

        void UpdateAnswer(AccountDTO account, int taskId, string notes);

        void UpdateLoginAndPassword(int credentialsId, string login, string password);
    }
}