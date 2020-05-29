namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;

    public interface IAdministratorService : IDisposable
    {
        AddressDTO GetAddressById(int id);

        IEnumerable<AddressDTO> GetAddressesByPlace(string country, string city, string street, string house);

        void CreateAddress(string country, string city, string street, string house, string apatrment, string notes);

        SkillDTO GeTSkillById(int id);

        SkillDTO GetSkillByName(string skill);

        void CreateSkill(string skill);

        CompetitionDTO GetCompetitionById(int id);

        void CreateCompetition(DateTime begin, DateTime end, string skill);

        void UpdateCompetition(CompetitionDTO competition);

        StageDTO GetStageById(int id);

        ICollection<StageDTO> GetStagesByCompetitionId(int id);

        void CreateStage(
            int competitionId,
            TypeStageDTO typeStageDto,
            ICollection<ParticipantDTO> participants,
            ICollection<AdministratorDTO> administrators,
            ICollection<JudgeDTO> judges);


        TaskDTO GetTaskById(int id);

        void CreateTask(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers);

        AdministratorDTO GetAdministratorById(int id);

        AdministratorDTO GetAdministratorByUserId(int id);

        ParticipantDTO GetParticipantById(int id);

        ParticipantDTO GetParticipantByUserId(int id);

        JudgeDTO GetJudgeById(int id);

        JudgeDTO GetJudgeByUserId(int id);

        TrainerDTO GetTrainerById(int id);

        TrainerDTO GetTrainerByUserId(int id);
    }
}