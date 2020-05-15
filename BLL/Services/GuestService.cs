namespace BLL.Services
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;

    public class GuestService : IDisposable
    {
        private UnitOfWork unitOfWork;

        public GuestService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public UserDTO GetUser(string login, string password)
        {
            var user = this.unitOfWork.UserRepository.Get(u => u.Login.Equals(login));
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
                this.unitOfWork.CompetitionRepository.GetList(c => c.DateTimeEnd >= DateTime.Now));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsBySkill(string skill)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.GetList(c => c.Skill.Name.Equals(skill)));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsByDate(DateTime begin, DateTime end)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.unitOfWork.CompetitionRepository.GetList(c => c.DateTimeBegin >= begin && c.DateTimeEnd <= end));
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