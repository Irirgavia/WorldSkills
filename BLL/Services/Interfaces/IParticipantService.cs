namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;
    using BLL.DTO.Account;
    using BLL.DTO.Competition;

    public interface IParticipantService : IDisposable
    {
        void RegisterAccountOnCompetition(int competitionId, StageTypeDTO stageType, int accountId);

        void UpdateAccount(AccountDTO account);

        void UpdateLoginAndPassword(AccountDTO account, string login, string password);

        IEnumerable<StageDTO> GetStages(AccountDTO account);

        AnswerDTO GetParticipantAnswer(AccountDTO account);

        void UpdateAnswer(AccountDTO account, int taskId, string notes);
    }
}