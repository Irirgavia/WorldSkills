namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class GuestService : IDisposable
    {
        private IUnitOfWork unitOfWork;

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

        public UserDTO GetUser(string login, string password)
        {
            var user = this.unitOfWork.UserRepository.GetUserByLogin(login);
            if (user == null)
            {
                return null;
            }

            if (!PasswordHasher.Verify(password, user.Password))
            {
                return null;
            }

            return ObjectMapper<UserEntity, UserDTO>.Map(user);
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
        
        public IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int year)
        {
            var competitionsEF = this.unitOfWork.CompetitionRepository.Get(c => 
                c.Skill.Name == skill &&
                (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year)  &&
                (c.DateTimeBegin.Year == year + 1 || c.DateTimeBegin.Year == year));
            
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(competitionsEF);
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