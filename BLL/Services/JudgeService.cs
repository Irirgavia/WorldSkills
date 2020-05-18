namespace BLL.Services
{
    using System;

    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class JudgeService : IDisposable
    {
        private IUnitOfWork unitOfWork;

        public JudgeService(string connection)
        {
            this.unitOfWork = new UnitOfWork(connection);
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