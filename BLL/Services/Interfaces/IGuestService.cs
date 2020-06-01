namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;

    public interface IGuestService : IDisposable
    {
        (AccountDTO account, bool isPasswordValid) GetAccount(string login, string password);

        IEnumerable<CompetitionDTO> GetAllCompetitions();

        IEnumerable<CompetitionDTO> GetActualCompetitions();

        IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int? year);

        IEnumerable<StageDTO> GetStagesBySkillAndYearAndTypeStage(string skill, int? year, string stageType);

        IEnumerable<CompetitionDTO> GetCompetitionsBySkill(string skill);

        IEnumerable<CompetitionDTO> GetCompetitionsByDateRange(DateTime begin, DateTime end);

        IEnumerable<CompetitionDTO> GetCompetitionsByDate(DateTime begin, DateTime end);
    }
}