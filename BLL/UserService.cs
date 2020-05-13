namespace BLL
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;

    public class UserService
    {
        private UnitOfWork unitOfWork;

        private PasswordHasher passwordHasher;

        public UserService()
        {
            this.unitOfWork = new UnitOfWork();
            this.ObjectMapper = new ObjectMapper();
        }

        public ObjectMapper ObjectMapper { get; }

        public ICollection<UserDTO> GetAllUsers()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.UserRepository.GetAll());
        }

        public void CreateAdministrator(UserDTO user, ICollection<StageDTO> stages)
        {
            //this.CreateUser();
            this.unitOfWork.AdministratorRepository.CreateAdministrator(ObjectMapper.ToDLO(user), ObjectMapper.ToDLOList(stages));

            this.unitOfWork.SaveChanges();
        }

        public ICollection<AdministratorDTO> GetAllAdministrators()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.AdministratorRepository.GetAll());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.unitOfWork?.Dispose();
            }
        }

        private void CreateUser(
            string login,
            string password,
            Role role,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards)
        {
            this.unitOfWork.UserRepository.CreateUser(login, password, role, surname, name, patronymic, birthday, photo, mail, telephone, awards);
        }
    }
}