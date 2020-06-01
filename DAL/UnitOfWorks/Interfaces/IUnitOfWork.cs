namespace DAL.UnitOfWorks.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}