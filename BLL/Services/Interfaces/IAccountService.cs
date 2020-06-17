namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;

    public interface IAccountService : IDisposable
    {
        AccountDTO CreateAccount(RegistrationForm registrationForm);

        AddressDTO CreateAccountAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes);

        RoleDTO CreateRole(string name);

        (AccountDTO account, bool isPasswordValid) GetAccount(string login, string password);

        AddressDTO GetAccountAddressById(int id);

        AccountDTO GetAccountById(int id);

        AccountDTO GetAccountByLogin(string login);

        IEnumerable<AccountDTO> GetAllAccounts();

        IEnumerable<AddressDTO> GetAddressesByPlace(
            string country,
            string city,
            string street,
            string house,
            string apartments);

        CredentialsDTO GetCredentialsById(int id);

        PersonalDataDTO GetPersonalDataById(int id);

        RoleDTO GetRoleById(int id);

        RoleDTO GetRoleByName(string name);

        bool IsFullNameAndBirthdayExist(string surname, string name, string patronymic, DateTime birthday);

        bool IsLoginExist(string login);

        bool IsRoleExist(string roleName);

        bool UpdateAccount(AccountDTO account);

        bool UpdateAccountAddress(AddressDTO address);

        bool UpdateCredentialsRole(int credentialsId, int roleId);

        bool UpdateLoginAndPassword(int credentialsId, string login, string password);

        bool UpdatePersonalData(PersonalDataDTO personalData);

        bool UpdateRole(RoleDTO role);
    }
}