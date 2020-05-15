namespace BLL.Services
{
    using System;

    using DAL.Repositories;

    public class JudgeService : IDisposable
    {
        private UnitOfWork unitOfWork;

        public JudgeService()
        {
            this.unitOfWork = new UnitOfWork();
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