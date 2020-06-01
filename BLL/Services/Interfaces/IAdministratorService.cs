namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;
    using BLL.DTO.NotificationSystem;

    public interface IAdministratorService : IDisposable
    {
        void CreateAccount(
            int roleId,
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            AddressDTO address);

        void CreateAccountAddress(
            string country,
            string city,
            string street,
            string house,
            string apartments,
            string notes);

        void CreateCompetitionAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes);

        void CreateAnswer(int accountId, int taskId, string projectLink, string notes);

        void CreateCompetition(DateTime begin, DateTime end, string skill);

        void CreateSkill(string skill);

        void CreateStage(int competitionId, int stageTypeId, ICollection<int> accounts);

        void CreateTask(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers);

        AccountDTO GetAccountById(int id);

        AccountDTO GetAccountByLogin(string login);


        AddressDTO GetAccountAddressById(int id);

        AddressDTO GetCompetitionAddressById(int id);

        IEnumerable<AddressDTO> GetAddressesByPlace(
            string country,
            string city,
            string street,
            string house,
            string apartments);

        AnswerDTO GetAnswerById(int id);

        CompetitionDTO GetCompetitionById(int id);

        CredentialsDTO GetCredentialsById(int id);

        PersonalDataDTO GetPersonalDataById(int id);

        PrizeDTO GetPrizeById(int id);

        RoleDTO GetRoleById(int id);

        RoleDTO GetRoleByName(string name);

        ResultDTO GetResultById(int id);

        SkillDTO GeTSkillById(int id);

        SkillDTO GetSkillByName(string skill);

        StageDTO GetStageById(int id);

        IEnumerable<StageDTO> GetStagesByAccountId(int id);

        ICollection<StageDTO> GetStagesByCompetitionId(int id);

        StageTypeDTO GetStageTypeById(int id);

        StageTypeDTO GetStageTypeByName(string name);

        TaskDTO GetTaskById(int id);

        MailDTO GetMailById(int id);

        NewsDTO GetNewsById(int id);

        NotificationDTO GetNotificationById(int id);

        void UpdateAccount(AccountDTO account);

        void UpdateAccountAddress(AddressDTO address);

        void UpdateCompetitionAddress(AddressDTO address);

        void UpdateCompetition(CompetitionDTO competition);

        void UpdateCredentials(CredentialsDTO credentials);

        void UpdatePersonalData(PersonalDataDTO personalData);

        void UpdateRole(RoleDTO role);
    }
}