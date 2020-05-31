namespace DAL.UnitOfWorks.Interfaces
{
    using System;

    using DAL.Entities.Account;
    using DAL.Repositories.Interfaces;

    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AccountEntity> AccountRepository { get; }

        void SaveChanges();
    }
}