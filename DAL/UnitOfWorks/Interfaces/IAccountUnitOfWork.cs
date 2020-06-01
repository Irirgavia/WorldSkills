namespace DAL.UnitOfWorks.Interfaces
{
    using DAL.Entities.Account;
    using DAL.Repositories.Interfaces;

    public interface IAccountUnitOfWork : IUnitOfWork
    {
        IGenericRepository<AccountEntity> AccountRepository { get; }

        IAddressRepository AddressRepository { get; }

        IGenericRepository<CredentialsEntity> CredentialsRepository { get; }

        IGenericRepository<PersonalDataEntity> PersonalDataRepository { get; }

        IGenericRepository<RoleEntity> RoleRepository { get; }
    }
}