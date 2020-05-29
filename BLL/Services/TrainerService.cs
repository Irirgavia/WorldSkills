namespace BLL.Services
{
    using System;
    using BLL.Services.Interfaces;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork unitOfWork;

        public TrainerService(string connection)
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