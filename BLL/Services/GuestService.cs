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

        public UserDTO GetUser(string login, string password)
        {
            var user = this.unitOfWork.UserRepository.Get(u => u.Login.Equals(login)).FirstOrDefault();
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