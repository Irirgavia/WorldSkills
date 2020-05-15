namespace BLL.Services
{
    using System;

    using BLL.DTO;

    using DAL.Repositories;

    public class TrainerService : IDisposable
    {
        private UnitOfWork unitOfWork;

        public TrainerService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public void CreateTrainer(UserDTO user)
        {
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