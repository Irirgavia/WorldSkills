namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;
    using DAL.Repositories.Interfaces;

    public class AdministratorService : IDisposable
    {
        private readonly IUnitOfWork unitOfWork;

        public AdministratorService(string connection)
        {
            this.unitOfWork = new UnitOfWork(connection);
        }

        public void CreateAddress(AddressDTO address)
        {
            this.unitOfWork.AddressRepository.Create(ObjectMapper<AddressDTO, AddressEntity>.Map(address));
            this.unitOfWork.SaveChanges();
        }

        public AddressDTO GetAddressById(int id)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.Map(this.unitOfWork.AddressRepository.Get(a => a.Id == id));
        }


        public void CreateSkill(string skill)
        {
            this.unitOfWork.SkillRepository.Create(new SkillEntity(skill));
            this.unitOfWork.SaveChanges();
        }

        public SkillDTO GetSkillByName(string skill)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(this.unitOfWork.SkillRepository.Get(s => s.Name == skill));
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

        public void CreateStage(StageDTO stage)
        {
            this.unitOfWork.StageRepository.Create(ObjectMapper<StageDTO, StageEntity>.Map(stage));
            this.unitOfWork.SaveChanges();
        }

        public ICollection<StageDTO> GetStagesByCompetition(CompetitionDTO competition)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.unitOfWork.StageRepository.GetList(s => s.CompetitionId == competition.Id))
                .ToList();
        }

        public void CreateTask(TaskDTO task)
        {
            this.unitOfWork.TaskRepository.Create(ObjectMapper<TaskDTO, TaskEntity>.Map(task));
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
