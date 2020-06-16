namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO.Account;
    using BLL.Services.Interfaces;
    using BLL.Utilities;

    using DAL.Entities.Account;
    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    public class AccountService : IAccountService
    {
        private readonly IAccountUnitOfWork accountUnitOfWork;

        public AccountService(string accountConnection)
        {
            this.accountUnitOfWork = new AccountUnitOfWork(accountConnection);
        }

        public AccountDTO CreateAccount(RegistrationForm registrationForm)
        {
            var role = this.accountUnitOfWork.RoleRepository.Get(r => r.Name == registrationForm.Role).FirstOrDefault();
            var accountAddress = this.accountUnitOfWork.AddressRepository.GetAddressesByPlace(
                                     registrationForm.PersonalData.Address.Country,
                                     registrationForm.PersonalData.Address.City,
                                     registrationForm.PersonalData.Address.Street,
                                     registrationForm.PersonalData.Address.House,
                                     registrationForm.PersonalData.Address.Apartments).FirstOrDefault()
                              ?? this.accountUnitOfWork.AddressRepository.Create(
                                     ObjectMapper<AddressDTO, AddressEntity>.Map(registrationForm.PersonalData.Address));

            var personalData = ObjectMapper<PersonalDataDTO, PersonalDataEntity>.Map(registrationForm.PersonalData);
            personalData.AddressEntity = accountAddress;

            AccountEntity account;

            try
            {
                var credentials = new CredentialsEntity(registrationForm.Login, PasswordHasher.Hash(registrationForm.Password), role.Id);
                account = this.accountUnitOfWork.AccountRepository.Create(new AccountEntity(personalData, credentials));
                this.accountUnitOfWork.SaveChanges();
            }
            catch (NullReferenceException)
            {
                return null;
            }

            return ObjectMapper<AccountEntity, AccountDTO>.Map(account);
        }

        public AddressDTO CreateAccountAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes)
        {
            var address = this.accountUnitOfWork.AddressRepository.Create(
                new AddressEntity(country, city, street, house, apartment, notes));
            this.accountUnitOfWork.SaveChanges();
            return ObjectMapper<AddressEntity, AddressDTO>.Map(address);
        }

        public RoleDTO CreateRole(string name)
        {
            RoleEntity role;

            try
            {
                role = this.accountUnitOfWork.RoleRepository.Create(new RoleEntity(name));
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<RoleEntity, RoleDTO>.Map(role);
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

            try
            {
                if (PasswordHasher.Verify(password, accountDto.Credentials.Password))
                    return (account: accountDto, isPasswordValid: true);
            }
            catch (NotSupportedException)
            {
                return (account: accountDto, isPasswordValid: false);
            }

            return (account: accountDto, isPasswordValid: false);
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
                this.accountUnitOfWork.AddressRepository.GetAddressesByPlace(country, city, street, house, apartments));
        }

        public CredentialsDTO GetCredentialsById(int id)
        {
            return ObjectMapper<CredentialsEntity, CredentialsDTO>.Map(
                this.accountUnitOfWork.CredentialsRepository.Get(c => c.Id == id).FirstOrDefault());
        }

        public PersonalDataDTO GetPersonalDataById(int id)
        {
            return ObjectMapper<PersonalDataEntity, PersonalDataDTO>.Map(
                this.accountUnitOfWork.PersonalDataRepository.Get(p => p.Id == id).FirstOrDefault());
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

        public bool IsFullNameAndBirthdayExist(string surname, string name, string patronymic, DateTime birthday)
        {
            var checkFullNameAndBirthday = this.accountUnitOfWork.PersonalDataRepository.Get(
                                                   p => p.Surname == surname && p.Name == name
                                                                             && p.Patronymic == patronymic
                                                                             && p.Birthday == birthday).FirstOrDefault();
            return checkFullNameAndBirthday != null;
        }

        public bool IsLoginExist(string login)
        {
            var checkLogin = this.accountUnitOfWork.CredentialsRepository.Get(c => c.Login == login).FirstOrDefault();
            return checkLogin != null;
        }

        public bool IsRoleExist(string roleName)
        {
            var checkRole = this.accountUnitOfWork.RoleRepository.Get(r => r.Name == roleName).FirstOrDefault();
            return checkRole != null;
        }

        public bool UpdateAccount(AccountDTO account)
        {
            try
            {
                this.accountUnitOfWork.AccountRepository.Update(ObjectMapper<AccountDTO, AccountEntity>.Map(account));
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateAccountAddress(AddressDTO address)
        {
            try
            {
                this.accountUnitOfWork.AddressRepository.Update(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCredentialsRole(int credentialsId, int roleId)
        {
            try
            {
                var credentials = this.accountUnitOfWork.CredentialsRepository.Get(c => c.Id == credentialsId).FirstOrDefault();
                credentials.RoleEntityId = roleId;

                this.accountUnitOfWork.CredentialsRepository.Update(credentials);
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateLoginAndPassword(int credentialsId, string login, string password)
        {
            try
            {
                var credentials = this.accountUnitOfWork.CredentialsRepository.Get(c => c.Id == credentialsId).FirstOrDefault();
                credentials.Login = login;
                credentials.Password = PasswordHasher.Hash(password);
                this.accountUnitOfWork.CredentialsRepository.Update(credentials);
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdatePersonalData(PersonalDataDTO personalData)
        {
            try
            {
                this.accountUnitOfWork.PersonalDataRepository.Update(
                    ObjectMapper<PersonalDataDTO, PersonalDataEntity>.Map(personalData));
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateRole(RoleDTO role)
        {
            try
            {
                this.accountUnitOfWork.RoleRepository.Update(ObjectMapper<RoleDTO, RoleEntity>.Map(role));
                this.accountUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) this.accountUnitOfWork?.Dispose();
        }
    }
}