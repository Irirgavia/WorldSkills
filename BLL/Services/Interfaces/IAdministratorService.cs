namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;

    public interface IAdministratorService : IDisposable
    {
        AddressDTO GetAddressById(int id);

        IEnumerable<AddressDTO> GetAddressesByPlace(string country, string city, string street, string house, string apartments);

        void CreateAddress(string country, string city, string street, string house, string apartments, string notes);

        void UpdateAddress(AddressDTO address);

        SkillDTO GeTSkillById(int id);

        SkillDTO GetSkillByName(string skill);

        void CreateSkill(string skill);

        CompetitionDTO GetCompetitionById(int id);

        void CreateCompetition(DateTime begin, DateTime end, string skill);

        void UpdateCompetition(CompetitionDTO competition);

        StageDTO GetStageById(int id);

        ICollection<StageDTO> GetStagesByCompetitionId(int id);

        void CreateStage(int competitionId, int stageTypeId, ICollection<AccountDTO> participants);


        TaskDTO GetTaskById(int id);

        void CreateTask(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers);

        void UpdatePersonalData(PersonalDataDTO personalData);
    }
}