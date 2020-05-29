namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using BLL.DTO;

    public interface IAdministratorService : IDisposable
    {
        void CreateAddress(string country, string city, string street, string house, string apatrment, string notes);

        IEnumerable<AddressDTO> GetAddressesByPlace(string country, string city, string street, string house);

        void CreateSkill(string skill);

        SkillDTO GetSkillByName(string skill);

        void CreateCompetition(DateTime begin, DateTime end, string skill);

        void UpdateCompetition(CompetitionDTO competition);

        CompetitionDTO GetCompetitionById(int id);

        void CreateStage(
            int competitionId,
            TypeStageDTO typeStageDto,
            ICollection<ParticipantDTO> participants,
            ICollection<AdministratorDTO> administrators,
            ICollection<JudgeDTO> judges);

        ICollection<StageDTO> GetStagesByCompetitionId(int id);

        void CreateTask(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers);

        ParticipantDTO GetParticipantById(int participantId);
    }
}