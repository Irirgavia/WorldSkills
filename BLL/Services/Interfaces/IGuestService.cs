namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;

    public interface IGuestService : IDisposable
    {
        (UserDTO user, bool isPasswordValid) GetUser(string login, string password);

        void CreateUser(
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards);

        IEnumerable<CompetitionDTO> GetAllCompetitions();

        IEnumerable<CompetitionDTO> GetActualCompetitions();

        IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int? year);

        IEnumerable<StageDTO> GetStagesBySkillAndYearAndTypeStage(string skill, int? year, TypeStageDTO typeStage);

        IEnumerable<CompetitionDTO> GetCompetitionsBySkill(string skill);

        IEnumerable<CompetitionDTO> GetCompetitionsByDateRange(DateTime begin, DateTime end);

        IEnumerable<CompetitionDTO> GetCompetitionsByDate(DateTime begin, DateTime end);
    }
}