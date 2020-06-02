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

        void CreateAnswer(int accountId, int taskId, string projectLink, string notes);

        void CreateCompetition(DateTime begin, DateTime end, string skill);

        void CreateCompetitionAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes);


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

        AddressDTO GetAccountAddressById(int id);

        AccountDTO GetAccountById(int id);

        AccountDTO GetAccountByLogin(string login);

        IEnumerable<AddressDTO> GetAddressesByPlace(
            string country,
            string city,
            string street,
            string house,
            string apartments);

        AnswerDTO GetAnswerById(int id);

        AddressDTO GetCompetitionAddressById(int id);

        CompetitionDTO GetCompetitionById(int id);

        CredentialsDTO GetCredentialsById(int id);

        MailDTO GetMailById(int id);

        NewsDTO GetNewsById(int id);

        NotificationDTO GetNotificationById(int id);

        PersonalDataDTO GetPersonalDataById(int id);

        PrizeDTO GetPrizeById(int id);

        ResultDTO GetResultById(int id);

        RoleDTO GetRoleById(int id);

        RoleDTO GetRoleByName(string name);

        SkillDTO GeTSkillById(int id);

        SkillDTO GetSkillByName(string skill);

        StageDTO GetStageById(int id);

        IEnumerable<StageDTO> GetStagesByAccountId(int id);

        ICollection<StageDTO> GetStagesByCompetitionId(int id);

        StageTypeDTO GetStageTypeById(int id);

        StageTypeDTO GetStageTypeByName(string name);

        TaskDTO GetTaskById(int id);

        void UpdateAccount(AccountDTO account);

        void UpdateAccountAddress(AddressDTO address);

        void UpdateCompetition(CompetitionDTO competition);

        void UpdateCompetitionAddress(AddressDTO address);

        void UpdateCredentials(CredentialsDTO credentials);

        void UpdatePersonalData(PersonalDataDTO personalData);

        void UpdatePrize(PrizeDTO prize);

        void UpdateResult(ResultDTO result);

        void UpdateRole(RoleDTO role);

        void UpdateSkill(SkillDTO skill);

        void UpdateStage(StageDTO stage);

        void UpdateStageType(StageTypeDTO stageType);

        void UpdateTask(TaskDTO task);

        void UpdateMail(MailDTO mail);

        void UpdateNews(NewsDTO news);

        void UpdateNotification(NotificationDTO notification);
    }
}