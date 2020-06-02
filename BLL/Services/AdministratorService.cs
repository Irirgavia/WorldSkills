namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;
    using BLL.DTO.NotificationSystem;
    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Entities.Account;
    using DAL.Entities.Competition;
    using DAL.Entities.NotificationSystem;
    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    public class AdministratorService : IAdministratorService
    {
        private readonly IAccountUnitOfWork accountUnitOfWork;

        private readonly ICompetitionUnitOfWork competitionUnitOfWork;

        private readonly ISystemUnitOfWork systemUnitOfWork;

        public AdministratorService(
            string accountConnection,
            string competitionConnection,
            string notificationConnection)
        {
            this.competitionUnitOfWork = new CompetitionUnitOfWork(competitionConnection);
            this.accountUnitOfWork = new AccountUnitOfWork(accountConnection);
            this.systemUnitOfWork = new SystemUnitOfWork(notificationConnection);
        }

        public void CreateAccount(
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
            AddressDTO address)
        {
            var accountAddress = this.accountUnitOfWork.AddressRepository.GetAddressesByPlace(
                                     address.Country,
                                     address.City,
                                     address.Street,
                                     address.House,
                                     address.Apartments).FirstOrDefault()
                              ?? this.accountUnitOfWork.AddressRepository.Create(
                                     ObjectMapper<AddressDTO, AddressEntity>.Map(address));

            var personalData = new PersonalDataEntity(
                surname,
                name,
                patronymic,
                birthday,
                photo,
                mail,
                telephone,
                accountAddress.Id);

            var role = this.accountUnitOfWork.RoleRepository.Get(r => r.Id == roleId).FirstOrDefault();
            var credentials = new CredentialsEntity(login, PasswordHasher.Hash(password), role.Id);

            this.accountUnitOfWork.AccountRepository.Create(new AccountEntity(personalData, credentials));
            this.accountUnitOfWork.SaveChanges();
        }

        public void CreateAccountAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes)
        {
            this.accountUnitOfWork.AddressRepository.Create(
                new AddressEntity(country, city, street, house, apartment, notes));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateAnswer(int accountId, int taskId, string projectLink, string notes)
        {
            var answer = new AnswerEntity(accountId, new ResultEntity(), taskId, projectLink, notes);
            this.competitionUnitOfWork.AnswerRepository.Create(answer);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateCompetition(DateTime begin, DateTime end, string skill)
        {
            var skillEf = this.competitionUnitOfWork.SkillRepository.GetOrCreate(
                new SkillEntity(skill),
                s => s.Name == skill);

            this.competitionUnitOfWork.CompetitionRepository.Create(
                new CompetitionEntity(skillEf.Id, begin, end, new List<StageEntity>()));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateCompetitionAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes)
        {
            this.competitionUnitOfWork.AddressRepository.Create(
                new AddressEntity(country, city, street, house, apartment, notes));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateSkill(string skill)
        {
            this.competitionUnitOfWork.SkillRepository.Create(new SkillEntity(skill));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateStage(int competitionId, int stageTypeId, ICollection<int> accounts)
        {
            var stage = new StageEntity(competitionId, stageTypeId, new List<TaskEntity>(), accounts);
            this.competitionUnitOfWork.StageRepository.Create(stage);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateTask(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers)
        {
            var task = new TaskEntity(
                stage,
                dateTime,
                time,
                description,
                requirement,
                ObjectMapper<AddressDTO, AddressEntity>.MapList(addresses).ToArray(),
                ObjectMapper<AnswerDTO, AnswerEntity>.MapList(answers).ToArray());
            this.competitionUnitOfWork.TaskRepository.Create(task);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public AddressDTO GetAccountAddressById(int id)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.Map(
                this.accountUnitOfWork.AddressRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public AccountDTO GetAccountById(int id)
        {
            return ObjectMapper<AccountEntity, AccountDTO>.Map(
                this.accountUnitOfWork.AccountRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public AccountDTO GetAccountByLogin(string login)
        {
            return ObjectMapper<AccountEntity, AccountDTO>.Map(
                this.accountUnitOfWork.AccountRepository.Get(a => a.CredentialsIdEntity.Login == login)
                    .FirstOrDefault());
        }

        public IEnumerable<AddressDTO> GetAddressesByPlace(
            string country,
            string city,
            string street,
            string house,
            string apartments)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.MapList(
                this.competitionUnitOfWork.AddressRepository.GetAddressesByPlace(
                    country,
                    city,
                    street,
                    house,
                    apartments));
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return ObjectMapper<NewsEntity, NewsDTO>.MapList(this.systemUnitOfWork.NewsRepository.GetAll());
        }

        public AnswerDTO GetAnswerById(int id)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.Map(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public AddressDTO GetCompetitionAddressById(int id)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.Map(
                this.competitionUnitOfWork.AddressRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public CompetitionDTO GetCompetitionById(int id)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.Map(
                this.competitionUnitOfWork.CompetitionRepository.Get(c => c.Id == id).FirstOrDefault());
        }

        public CredentialsDTO GetCredentialsById(int id)
        {
            return ObjectMapper<CredentialsEntity, CredentialsDTO>.Map(
                this.accountUnitOfWork.CredentialsRepository.Get(c => c.Id == id).FirstOrDefault());
        }

        public MailDTO GetMailById(int id)
        {
            return ObjectMapper<MailEntity, MailDTO>.Map(
                this.systemUnitOfWork.MailRepository.Get(m => m.Id == id).FirstOrDefault());
        }

        public IEnumerable<NewsDTO> GetNewsByDataRange(DateTime begin, DateTime end)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.MapList(
                this.systemUnitOfWork.NewsRepository.Get(
                    n => n.PublicationDateTime >= begin && n.PublicationDateTime <= end));
        }

        public IEnumerable<NewsDTO> GetNewsByFromAccountId(int id)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.MapList(
                this.systemUnitOfWork.NewsRepository.Get(
                    n => n.AccountIdFrom == id));
        }

        public NewsDTO GetNewsById(int id)
        {
            return ObjectMapper<NewsEntity, NewsDTO>.Map(
                this.systemUnitOfWork.NewsRepository.Get(n => n.Id == id).FirstOrDefault());
        }

        public IEnumerable<NotificationDTO> GetNotificationByFromAccountId(int id)
        {
            return ObjectMapper<NotificationEntity, NotificationDTO>.MapList(
                this.systemUnitOfWork.NotificationRepository.Get(
                    n => n.MailEntity.AccountIdFrom == id));
        }

        public NotificationDTO GetNotificationById(int id)
        {
            return ObjectMapper<NotificationEntity, NotificationDTO>.Map(
                this.systemUnitOfWork.NotificationRepository.Get(n => n.Id == id).FirstOrDefault());
        }

        public IEnumerable<NotificationDTO> GetNotificationByToAccountId(int id)
        {
            return ObjectMapper<NotificationEntity, NotificationDTO>.MapList(
                this.systemUnitOfWork.NotificationRepository.Get(
                    n => n.MailEntity.AccountIdsTo.Contains(id)));
        }

        public PersonalDataDTO GetPersonalDataById(int id)
        {
            return ObjectMapper<PersonalDataEntity, PersonalDataDTO>.Map(
                this.accountUnitOfWork.PersonalDataRepository.Get(p => p.Id == id).FirstOrDefault());
        }

        public PrizeDTO GetPrizeById(int id)
        {
            return ObjectMapper<PrizeEntity, PrizeDTO>.Map(
                this.competitionUnitOfWork.PrizeRepository.Get(p => p.Id == id).FirstOrDefault());
        }

        public ResultDTO GetResultById(int id)
        {
            return ObjectMapper<ResultEntity, ResultDTO>.Map(
                this.competitionUnitOfWork.ResultRepository.Get(r => r.Id == id).FirstOrDefault());
        }

        public RoleDTO GetRoleById(int id)
        {
            return ObjectMapper<RoleEntity, RoleDTO>.Map(
                this.accountUnitOfWork.RoleRepository.Get(r => r.Id == id).FirstOrDefault());
        }

        public RoleDTO GetRoleByName(string name)
        {
            return ObjectMapper<RoleEntity, RoleDTO>.Map(
                this.accountUnitOfWork.RoleRepository.Get(r => r.Name == name).FirstOrDefault());
        }

        public SkillDTO GeTSkillById(int id)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(
                this.competitionUnitOfWork.SkillRepository.Get(s => s.Id == id).FirstOrDefault());
        }

        public SkillDTO GetSkillByName(string skill)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(
                this.competitionUnitOfWork.SkillRepository.Get(s => s.Name == skill).FirstOrDefault());
        }

        public StageDTO GetStageById(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.Map(
                this.competitionUnitOfWork.StageRepository.Get(s => s.Id == id).FirstOrDefault());
        }

        public IEnumerable<StageDTO> GetStagesByAccountId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(s => s.AccountIds.Contains(id)));
        }

        public ICollection<StageDTO> GetStagesByCompetitionId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(
                    s => s.CompetitionEntityId == id)).ToList();
        }

        public StageTypeDTO GetStageTypeById(int id)
        {
            return ObjectMapper<StageTypeEntity, StageTypeDTO>.Map(
                this.competitionUnitOfWork.StageTypeRepository.Get(s => s.Id == id).FirstOrDefault());
        }

        public StageTypeDTO GetStageTypeByName(string name)
        {
            return ObjectMapper<StageTypeEntity, StageTypeDTO>.Map(
                this.competitionUnitOfWork.StageTypeRepository.Get(s => s.Name == name).FirstOrDefault());
        }

        public TaskDTO GetTaskById(int id)
        {
            return ObjectMapper<TaskEntity, TaskDTO>.Map(
                this.competitionUnitOfWork.TaskRepository.Get(t => t.Id == id).FirstOrDefault());
        }

        public void UpdateAccount(AccountDTO account)
        {
            this.accountUnitOfWork.AccountRepository.Update(ObjectMapper<AccountDTO, AccountEntity>.Map(account));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateAccountAddress(AddressDTO address)
        {
            this.accountUnitOfWork.AddressRepository.Update(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateCompetition(CompetitionDTO competition)
        {
            this.competitionUnitOfWork.CompetitionRepository.Update(
                ObjectMapper<CompetitionDTO, CompetitionEntity>.Map(competition));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateCompetitionAddress(AddressDTO address)
        {
            this.competitionUnitOfWork.AddressRepository.Update(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateCredentials(CredentialsDTO credentials)
        {
            this.accountUnitOfWork.CredentialsRepository.Update(
                ObjectMapper<CredentialsDTO, CredentialsEntity>.Map(credentials));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateMail(MailDTO mail)
        {
            this.systemUnitOfWork.MailRepository.Update(ObjectMapper<MailDTO, MailEntity>.Map(mail));
            this.systemUnitOfWork.SaveChanges();
        }

        public void UpdateNews(NewsDTO news)
        {
            this.systemUnitOfWork.NewsRepository.Update(ObjectMapper<NewsDTO, NewsEntity>.Map(news));
            this.systemUnitOfWork.SaveChanges();
        }

        public void UpdateNotification(NotificationDTO notification)
        {
            this.systemUnitOfWork.NotificationRepository.Update(
                ObjectMapper<NotificationDTO, NotificationEntity>.Map(notification));
            this.systemUnitOfWork.SaveChanges();
        }

        public void UpdatePersonalData(PersonalDataDTO personalData)
        {
            this.accountUnitOfWork.PersonalDataRepository.Update(
                ObjectMapper<PersonalDataDTO, PersonalDataEntity>.Map(personalData));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdatePrize(PrizeDTO prize)
        {
            this.competitionUnitOfWork.PrizeRepository.Update(ObjectMapper<PrizeDTO, PrizeEntity>.Map(prize));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateResult(ResultDTO result)
        {
            this.competitionUnitOfWork.ResultRepository.Update(ObjectMapper<ResultDTO, ResultEntity>.Map(result));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateRole(RoleDTO role)
        {
            this.accountUnitOfWork.RoleRepository.Update(ObjectMapper<RoleDTO, RoleEntity>.Map(role));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateSkill(SkillDTO skill)
        {
            this.competitionUnitOfWork.SkillRepository.Update(ObjectMapper<SkillDTO, SkillEntity>.Map(skill));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateStage(StageDTO stage)
        {
            this.competitionUnitOfWork.StageRepository.Update(ObjectMapper<StageDTO, StageEntity>.Map(stage));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateStageType(StageTypeDTO stageType)
        {
            this.competitionUnitOfWork.StageTypeRepository.Update(
                ObjectMapper<StageTypeDTO, StageTypeEntity>.Map(stageType));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateTask(TaskDTO task)
        {
            this.competitionUnitOfWork.TaskRepository.Update(ObjectMapper<TaskDTO, TaskEntity>.Map(task));
            this.competitionUnitOfWork.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.competitionUnitOfWork?.Dispose();
            }
        }
    }
}