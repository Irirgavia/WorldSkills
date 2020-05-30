namespace BLL.Services
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;
    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Entities;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class GuestService : IGuestService
    {
        private readonly IUnitOfWork unitOfWork;

        public GuestService(string connection)
        {
            this.unitOfWork = new UnitOfWork(connection);
        }

        public void CreateUser(
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards)
        {
            var hashPassword = PasswordHasher.Hash(password);
            var user = new UserEntity(login, hashPassword, Role.User, surname, name, patronymic, birthday, photo, mail, telephone, awards);
            this.unitOfWork.UserRepository.Create(user);
            this.unitOfWork.SaveChanges();
        }

        public (UserDTO user, bool isPasswordValid) GetUser(string login, string password)
        {
            var userDto = ObjectMapper<UserEntity, UserDTO>.Map(this.unitOfWork.UserRepository.GetUserByLogin(login));
            if (userDto == null)
            {
                return (user: null, isPasswordValid: false);
            }

            if (!PasswordHasher.Verify(password, userDto.Password))
            {
                return (user: userDto, isPasswordValid: false);
            }

            return (user: userDto, isPasswordValid: true);
        }

        public IEnumerable<CompetitionDTO> GetAllCompetitions()
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.GetAll());
        }

        public IEnumerable<CompetitionDTO> GetActualCompetitions()
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.Get(c => c.DateTimeEnd >= DateTime.Now));
        }
        
        public IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int? year)
        {
            if (skill != null && year != null)
            {
               return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                    this.unitOfWork.CompetitionRepository.Get(
                        c => 
                            c.Skill.Name == skill &&
                            (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year) && 
                            (c.DateTimeEnd.Year == year + 1 || c.DateTimeEnd.Year == year)));
            }

            if (skill != null)
            {
                return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                    this.unitOfWork.CompetitionRepository.Get(
                        c =>
                            c.Skill.Name == skill));
            }

            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.Get(
                    c =>
                        (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year) &&
                        (c.DateTimeEnd.Year == year + 1 || c.DateTimeEnd.Year == year)));
        }

        public IEnumerable<StageDTO> GetStagesBySkillAndYearAndTypeStage(string skill, int? year, TypeStageDTO typeStage)
        {
            var competitions = GetCompetitionsBySkillAndYear(skill, year);
            var stages = new List<StageDTO>();
            foreach (var competition in competitions)
            {
                foreach (var stage in competition.Stages)
                {
                    if (stage.TypeStageDto.Equals(typeStage))
                    {
                        stages.Add(stage);
                    }
                }
            }

            return stages;
        }
        
        public IEnumerable<CompetitionDTO> GetCompetitionsBySkill(string skill)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.Get(c => c.Skill.Name.Equals(skill)));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsByDateRange(DateTime begin, DateTime end)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.Get(c => c.DateTimeBegin >= begin && c.DateTimeEnd <= end));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsByDate(DateTime begin, DateTime end)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.Get(c => c.DateTimeBegin == begin && c.DateTimeEnd == end));
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork?.Dispose();
            }
        }
    }
}