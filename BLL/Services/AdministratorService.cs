namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Abp.AutoMapper;

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

        public void CreateAddress(string country, string city, string street, string house, string apatrment, string notes)
        {
            this.unitOfWork.AddressRepository.Create(new AddressEntity(country, city, street, house, apatrment, notes));
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
            var competitionEF = new CompetitionEntity() { DateTimeBegin = begin, DateTimeEnd = end, SkillEntityId = skillEF.Id };
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

        public void CreateStage(
            int competitionId,
            TypeStageDTO typeStageDto,
            ICollection<ParticipantDTO> participants,
            ICollection<AdministratorDTO> administrators,
            ICollection<JudgeDTO> judges)
        {

            var stage = new StageEntity(
                competitionId,
                ObjectMapper<TypeStageDTO, TypeStageEntity>.Map(typeStageDto), 
                new List<TaskEntity>(),
                ObjectMapper<ParticipantDTO, ParticipantEntity>.MapList(participants).ToArray(),
                ObjectMapper<JudgeDTO, JudgeEntity>.MapList(judges).ToArray(),
                ObjectMapper<AdministratorDTO, AdministratorEntity>.MapList(administrators).ToArray());
            this.unitOfWork.StageRepository.Create(stage);
            this.unitOfWork.SaveChanges();
        }

        public ICollection<StageDTO> GetStagesByCompetitionId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.unitOfWork.StageRepository.Get(s => s.CompetitionEntityId == id))
                .ToList();
        }

        public void CreateTask(
            int stage,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            ICollection<AddressDTO> addresses,
            ICollection<AnswerDTO> answers)
        {
            var task = new TaskEntity(
                stage, 
                dateTime,
                time,
                description,
                requirement, 
                ObjectMapper<AddressDTO, AddressEntity>.MapList(addresses).ToArray(),
                ObjectMapper<AnswerDTO, AnswerEntity>.MapList(answers).ToArray());
            this.unitOfWork.TaskRepository.Create(task);
            this.unitOfWork.SaveChanges();
        }

        public ParticipantDTO GetParticipantById(int participantId)
        {
            return ObjectMapper<ParticipantEntity, ParticipantDTO>.Map(
                this.unitOfWork.ParticipantRepository.Get(p => p.Id == participantId).FirstOrDefault());
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
