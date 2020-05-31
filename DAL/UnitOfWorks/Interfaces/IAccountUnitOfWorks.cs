namespace DAL.UnitOfWorks.Interfaces
{
    using DAL.Entities.Account;
    using DAL.Repositories.Interfaces;

    public interface IAccountUnitOfWorks : IUnitOfWork
    {
        IAddressRepository AddressRepository { get; }

        IGenericRepository<CredentialsEntity> CredentialsRepository { get; }

        IGenericRepository<PersonalDataEntity> PersonalDataRepository { get; }

        IGenericRepository<RoleEntity> RoleRepository { get; }
    }
}