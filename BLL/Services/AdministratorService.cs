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

        public void CreateAddress(string country, string city, string street, string house, string notes)
        {
            this.unitOfWork.AddressRepository.Create(new AddressEntity(country, city, street, house, notes));
            this.unitOfWork.SaveChanges();
        }

        public IEnumerable<AddressDTO> GetAddressesByPlace(string country, string city, string street, string house)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.MapList(this.unitOfWork.AddressRepository.GetAddressesByPlace(country, city, street, house));
        }

        public void CreateSkill(string skill)
        {
            this.unitOfWork.SkillRepository.Create(new SkillEntity(skill));
            this.unitOfWork.SaveChanges();
        }

        public SkillDTO GetSkillByName(string skill)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(this.unitOfWork.SkillRepository.GetSkillByName(skill));
        }

        public void CreateCompetition(DateTime begin, DateTime end, SkillDTO skill)
        {
            var skillEF = this.unitOfWork.SkillRepository.Get(s => s.Name.Equals(skill.Name)).FirstOrDefault();
            var competitionEF = new CompetitionEntity() { DateTimeBegin = begin, DateTimeEnd = end, SkillId = skillEF.Id };
            this.unitOfWork.CompetitionRepository.Create(competitionEF);

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
                this.unitOfWork.CompetitionRepository.Get(c => c.Id == id).FirstOrDefault());
        }

        public void CreateStage(StageDTO stage)
        {
            this.unitOfWork.StageRepository.Create(ObjectMapper<StageDTO, StageEntity>.Map(stage));
            this.unitOfWork.SaveChanges();
        }

        public ICollection<StageDTO> GetStagesByCompetition(CompetitionDTO competition)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.unitOfWork.StageRepository.Get(s => s.CompetitionId == competition.Id))
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
