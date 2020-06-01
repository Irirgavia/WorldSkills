namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;
    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Entities.Account;
    using DAL.Entities.Competition;
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
            this.systemUnitOfWork = new DAL.UnitOfWorks.SystemUnitOfWork(notificationConnection);
        }

        public void CreateAddress(
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

        public void CreateAnswer(int participant, int taskId, string projectLink, string notes)
        {
            var answer = new AnswerEntity(participant, new ResultEntity(), taskId, projectLink, notes);

            this.competitionUnitOfWork.AnswerRepository.Create(answer);
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateCompetition(DateTime begin, DateTime end, string skill)
        {
            var skillEf = this.competitionUnitOfWork.SkillRepository.GetOrCreate(
                new SkillEntity(skill),
                s => s.Name == skill);

            this.competitionUnitOfWork.CompetitionRepository.Create(
                new CompetitionEntity { DateTimeBegin = begin, DateTimeEnd = end, SkillEntityId = skillEf.Id });

            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateSkill(string skill)
        {
            this.competitionUnitOfWork.SkillRepository.Create(new SkillEntity(skill));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void CreateStage(int competitionId, int stageTypeId, ICollection<AccountDTO> accounts)
        {
            var stage = new StageEntity(
                competitionId,
                stageTypeId,
                new List<TaskEntity>(),
                new List<int>());
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

        public AccountDTO GetAccountById(int id)
        {
            return ObjectMapper<AccountEntity, AccountDTO>.Map(this.accountUnitOfWork.AccountRepository.GetById(id));
        }

        public AccountDTO GetAccountByLogin(string login)
        {
            return ObjectMapper<AccountEntity, AccountDTO>.Map(
                this.accountUnitOfWork.AccountRepository.Get(a => a.CredentialsIdEntity.Login == login)
                    .FirstOrDefault());
        }

        public AddressDTO GetAddressById(int id)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.Map(
                this.competitionUnitOfWork.AddressRepository.GetById(id));
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

        public CompetitionDTO GetCompetitionById(int id)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.Map(
                this.competitionUnitOfWork.CompetitionRepository.Get(c => c.Id == id).FirstOrDefault());
        }

        public CredentialsDTO GetCredentialsById(int id)
        {
            return ObjectMapper<CredentialsEntity, CredentialsDTO>.Map(
                this.accountUnitOfWork.CredentialsRepository.GetById(id));
        }

        public PersonalDataDTO GetPersonalDataById(int id)
        {
            return ObjectMapper<PersonalDataEntity, PersonalDataDTO>.Map(
                this.accountUnitOfWork.PersonalDataRepository.GetById(id));
        }

        public RoleDTO GetRoleById(int id)
        {
            return ObjectMapper<RoleEntity, RoleDTO>.Map(this.accountUnitOfWork.RoleRepository.GetById(id));
        }

        public RoleDTO GetRoleByName(string name)
        {
            return ObjectMapper<RoleEntity, RoleDTO>.Map(
                this.accountUnitOfWork.RoleRepository.Get(r => r.Name == name).FirstOrDefault());
        }

        public SkillDTO GeTSkillById(int id)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(this.competitionUnitOfWork.SkillRepository.GetById(id));
        }

        public SkillDTO GetSkillByName(string skill)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(
                this.competitionUnitOfWork.SkillRepository.Get(s => s.Name == skill).FirstOrDefault());
        }

        public StageDTO GetStageById(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.Map(this.competitionUnitOfWork.StageRepository.GetById(id));
        }

        public ICollection<StageDTO> GetStagesByCompetitionId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(
                    s => s.CompetitionEntityId == id)).ToList();
        }

        public StageTypeDTO GetStageTypeByName(string name)
        {
            return ObjectMapper<StageTypeEntity, StageTypeDTO>.Map(
                this.competitionUnitOfWork.StageTypeRepository.Get(s => s.Name == name).FirstOrDefault());
        }

        public TaskDTO GetTaskById(int id)
        {
            return ObjectMapper<TaskEntity, TaskDTO>.Map(this.competitionUnitOfWork.TaskRepository.GetById(id));
        }

        public void UpdateAccount(AccountDTO account)
        {
            this.accountUnitOfWork.AccountRepository.Update(ObjectMapper<AccountDTO, AccountEntity>.Map(account));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateAddress(AddressDTO address)
        {
            this.competitionUnitOfWork.AddressRepository.Update(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateCompetition(CompetitionDTO competition)
        {
            this.competitionUnitOfWork.CompetitionRepository.Update(
                ObjectMapper<CompetitionDTO, CompetitionEntity>.Map(competition));
            this.competitionUnitOfWork.SaveChanges();
        }

        public void UpdateCredentials(CredentialsDTO credentials)
        {
            this.accountUnitOfWork.CredentialsRepository.Update(
                ObjectMapper<CredentialsDTO, CredentialsEntity>.Map(credentials));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdatePersonalData(PersonalDataDTO personalData)
        {
            this.accountUnitOfWork.PersonalDataRepository.Update(
                ObjectMapper<PersonalDataDTO, PersonalDataEntity>.Map(personalData));
            this.accountUnitOfWork.SaveChanges();
        }

        public void UpdateRole(RoleDTO role)
        {
            this.accountUnitOfWork.RoleRepository.Update(ObjectMapper<RoleDTO, RoleEntity>.Map(role));
            this.accountUnitOfWork.SaveChanges();
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