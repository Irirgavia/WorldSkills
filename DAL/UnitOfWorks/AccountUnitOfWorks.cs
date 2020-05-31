namespace DAL.UnitOfWorks
{
    using System;

    using DAL.Contexts;
    using DAL.Entities.Account;
    using DAL.Repositories;
    using DAL.Repositories.Account;
    using DAL.Repositories.Interfaces;
    using DAL.UnitOfWorks.Interfaces;

    public class AccountUnitOfWorks : IAccountUnitOfWorks
    {
        private readonly AccountContext accountContext;

        public AccountUnitOfWorks(string connectionString)
        {
            this.accountContext = new AccountContext(connectionString);
        }

        public IGenericRepository<AccountEntity> AccountRepository =>
            new AccountRepository(this.accountContext);

        public IAddressRepository AddressRepository =>
            new AddressRepository(this.accountContext);

        public IGenericRepository<CredentialsEntity> CredentialsRepository =>
            new CredentialsRepository(this.accountContext);

        public IGenericRepository<PersonalDataEntity> PersonalDataRepository =>
            new PersonalDataRepository(this.accountContext);

        public IGenericRepository<RoleEntity> RoleRepository =>
            new GenericRepository<RoleEntity, AccountContext>(this.accountContext);


        public void SaveChanges()
        {
            this.accountContext.SaveChanges();
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
                this.accountContext?.Dispose();
            }
        }
    }
}