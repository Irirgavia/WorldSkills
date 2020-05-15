namespace BLL.Services
{
    using System;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;

    public class AdministratorService : IDisposable
    {
        private UnitOfWork unitOfWork;

        public AdministratorService()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public void CreateCompetition(CompetitionDTO competition)
        {
            this.unitOfWork.CompetitionRepository.Create(ObjectMapper<CompetitionDTO, CompetitionEntity>.Map(competition));
            this.unitOfWork.SaveChanges();
        }

        public void UpdateCompetition(CompetitionDTO competition)
        {
            this.unitOfWork.CompetitionRepository.Update(ObjectMapper<CompetitionDTO, CompetitionEntity>.Map(competition));
            this.unitOfWork.SaveChanges();
        }

        public CompetitionDTO GetCompetitionById(int id)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.Map(
                this.unitOfWork.CompetitionRepository.Get(c => c.Id == id));
        }

        public void CreateOrUpdateStage(StageDTO stage)
        {
            this.unitOfWork.StageRepository.CreateOrUpdate(ObjectMapper<StageDTO, StageEntity>.Map(stage));
            this.unitOfWork.SaveChanges();
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
