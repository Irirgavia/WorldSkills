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

    public class GuestService : IGuestService
    {
        private readonly IAccountUnitOfWork accountUnitOfWork;

        private readonly ICompetitionUnitOfWork competitionUnitOfWork;

        public GuestService(string connection)
        {
            this.competitionUnitOfWork = new CompetitionUnitOfWork(connection);
            this.accountUnitOfWork = new AccountUnitOfWork(connection);
        }

        public void CreateParticipant(
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
                address.Apartments).FirstOrDefault();

            if (accountAddress == null)
            {
            }

            var personalData = new PersonalDataEntity(
                surname,
                name,
                patronymic,
                birthday,
                photo,
                mail,
                telephone,
                accountAddress);

            var role = this.accountUnitOfWork.RoleRepository.Get(r => r.Name == "Participant").FirstOrDefault();
            var credentials = new CredentialsEntity(login, PasswordHasher.Hash(password), role.Id);

            this.accountUnitOfWork.AccountRepository.Create(new AccountEntity(personalData, credentials));
            this.accountUnitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public (AccountDTO account, bool isPasswordValid) GetAccount(string login, string password)
        {
            var accountDto = ObjectMapper<AccountEntity, AccountDTO>.Map(
                this.accountUnitOfWork.AccountRepository.Get(a => a.CredentialsIdEntity.Login == login)
                    .FirstOrDefault());
            if (accountDto == null) return (account: null, isPasswordValid: false);

            if (!PasswordHasher.Verify(password, accountDto.Credentials.Password))
                return (account: accountDto, isPasswordValid: false);

            return (account: accountDto, isPasswordValid: true);
        }

        public IEnumerable<CompetitionDTO> GetActualCompetitions()
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(c => c.DateTimeEnd >= DateTime.Now));
        }

        public IEnumerable<CompetitionDTO> GetAllCompetitions()
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.GetAll());
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsByDate(DateTime begin, DateTime end)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(
                    c => c.DateTimeBegin == begin && c.DateTimeEnd == end));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsByDateRange(DateTime begin, DateTime end)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(
                    c => c.DateTimeBegin >= begin && c.DateTimeEnd <= end));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsBySkill(string skill)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(c => c.SkillEntity.Name.Equals(skill)));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int? year)
        {
            if (skill != null && year != null)
                return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                    this.competitionUnitOfWork.CompetitionRepository.Get(
                        c => 
                            c.SkillEntity.Name == skill 
                         && (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year) 
                         && (c.DateTimeEnd.Year == year + 1 || c.DateTimeEnd.Year == year)));

            if (skill != null)
                return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                    this.competitionUnitOfWork.CompetitionRepository.Get(c => c.SkillEntity.Name == skill));

            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(
                    c => 
                        (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year) && 
                        (c.DateTimeEnd.Year == year + 1 || c.DateTimeEnd.Year == year)));
        }

        public IEnumerable<StageDTO> GetStagesBySkillAndYearAndTypeStage(
            string skill,
            int? year,
            StageTypeDTO stageType)
        {
            var competitions = this.GetCompetitionsBySkillAndYear(skill, year);
            var stages = new List<StageDTO>();
            foreach (var competition in competitions)
            {
                foreach (var stage in competition.Stages)
                    if (stage.StageType.Name == stageType.Name)
                        stages.Add(stage);
            }

            return stages;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.competitionUnitOfWork?.Dispose();
                this.accountUnitOfWork?.Dispose();
            }
        }
    }
}