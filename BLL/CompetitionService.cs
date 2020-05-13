namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO;

    using DAL.Entities;
    using DAL.Repositories;

    public class CompetitionService : IDisposable
    {
        private UnitOfWork unitOfWork;

        public CompetitionService()
        {
            this.unitOfWork = new UnitOfWork();
            this.ObjectMapper = new ObjectMapper();
        }

        public ObjectMapper ObjectMapper { get; }

        public AddressDTO GetAddressById(int id)
        {
            return ObjectMapper.ToBLO(this.unitOfWork.AddressRepository.GetAddressById(id));
        }

        public ICollection<AddressDTO> GetAllAddressByPlace(string country, string city = null, string street = null, string house = null)
        {
            return ObjectMapper.ToBLOList(
                this.unitOfWork.AddressRepository.GetAddressesByPlace(country, city, street, house));
        }

        public ICollection<AddressDTO> GetAllAddress()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.AddressRepository.GetAll());
        }

        public void CreateAddress(string country, string city, string street, string house, string notes)
        {
            this.unitOfWork.AddressRepository.CreateAddress(country, city, street, house, notes);
            this.unitOfWork.SaveChanges();
        }

        public void DeleteAddress(int id)
        {
            this.unitOfWork.AddressRepository.DeleteAddress(id);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateAddress(AddressDTO address)
        {
            this.unitOfWork.AddressRepository.UpdateAddress(
                address.Id,
                address.Country,
                address.City,
                address.Street,
                address.House,
                address.Notes);

            this.unitOfWork.SaveChanges();
        }

        public AnswerDTO GetAnswer(int id)
        {
            return ObjectMapper.ToBLO(this.unitOfWork.AnswerRepository.GetAnswerById(id));
        }

        public ICollection<AnswerDTO> GetAnswersByTask(int id)
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.AnswerRepository.GetAnswersByIdTask(id));
        }

        public void CreateAnswer(int participantId, int taskId, string projectLink, string notes)
        {
            var participant = this.unitOfWork.ParticipantRepository.GetParticipantById(participantId);
            var task = this.unitOfWork.TaskRepository.GetTaskById(taskId);

            this.unitOfWork.ResultRepository.CreateResult();
            var result = this.unitOfWork.ResultRepository.GetResultById(this.unitOfWork.ResultRepository.GetAll().Count());

            this.unitOfWork.AnswerRepository.CreateAnswer(participant, result, task, projectLink, notes);
            this.unitOfWork.SaveChanges();
        }

        public void DeleteAnswer(int id)
        {
            this.unitOfWork.AnswerRepository.DeleteAnswer(id);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateAnswer(AnswerDTO answer)
        {
            this.unitOfWork.AnswerRepository.UpdateAnswer(
                answer.Id,
                answer.ProjectLink,
                answer.Notes);

            this.unitOfWork.SaveChanges();
        }

        public ICollection<CompetitionDTO> GetAllCompetitions()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.CompetitionRepository.GetAll());
        }

        public ICollection<CompetitionDTO> GetCompetitions(string skill)
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.CompetitionRepository.GetCompetitions(skill));
        }

        public ICollection<CompetitionDTO> GetCompetitions(DateTime begin, DateTime end)
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.CompetitionRepository.GetCompetitions(begin, end));
        }

        public CompetitionDTO GetCompetition(int id)
        {
            return ObjectMapper.ToBLO(this.unitOfWork.CompetitionRepository.GetCompetitionById(id));
        }

        public void CreateCompetition(
            string skillName,
            DateTime begin,
            DateTime end)
        {
            var skill = this.unitOfWork.SkillRepository.GetSkillByName(skillName);
            this.unitOfWork.CompetitionRepository.CreateCompetition(skill, begin, end, new List<StageEntity>());
            this.unitOfWork.SaveChanges();
        }

        public void DeleteCompetition(int id)
        {
            this.unitOfWork.CompetitionRepository.DeleteCompetition(id);
            this.unitOfWork.SaveChanges();
        }

        public void UpdateCompetition(CompetitionDTO competition)
        {
            foreach (var stage in competition.Stages)
            {
                UpdateStage(stage);
            }

            var competitionEntity = this.unitOfWork.CompetitionRepository.GetCompetitionById(competition.Id);
            var stages = this.unitOfWork.StageRepository.GetStagesByCompetition(competitionEntity).ToArray();
            this.unitOfWork.CompetitionRepository.UpdateCompetition(
                competition.Id,
                competition.DateTimeBegin,
                competition.DateTimeEnd,
                stages);

            this.unitOfWork.SaveChanges();
        }

        public ICollection<SkillDTO> GetAllSkills()
        {
            return ObjectMapper.ToBLOList(unitOfWork.SkillRepository.GetAll());
        }

        public SkillDTO GetSkillByName(string name)
        {
            return ObjectMapper.ToBLO(this.unitOfWork.SkillRepository.GetSkillByName(name));
        }

        public void CreateSkill(string name)
        {
            this.unitOfWork.SkillRepository.CreateSkill(name);
            this.unitOfWork.SaveChanges();
        }

        public ICollection<StageDTO> GetStagesByCompetition(int id)
        {
            var competition = this.unitOfWork.CompetitionRepository.GetCompetitionById(id);
            return ObjectMapper.ToBLOList(this.unitOfWork.StageRepository.GetStagesByCompetition(competition));
        }

        public ICollection<StageDTO> GetAllStages()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.StageRepository.GetAll());
        }

        public void CreateStage(
            int competitionId, 
            TypeStage typeStage,
            ICollection<TaskDTO> tasks,
            ICollection<ParticipantDTO> participants,
            ICollection<JudgeDTO> judges,
            ICollection<AdministratorDTO> administrators)
        {
            var competition = this.unitOfWork.CompetitionRepository.GetCompetitionById(competitionId);

            this.unitOfWork.StageRepository.CreateStage(
                competition,
                typeStage,
                ObjectMapper.ToDLOList(tasks),
                ObjectMapper.ToDLOList(participants),
                ObjectMapper.ToDLOList(judges),
                ObjectMapper.ToDLOList(administrators));

            this.unitOfWork.SaveChanges();
        }

        public void UpdateStage(StageDTO stage)
        {
            //this.unitOfWork.StageRepository.UpdateStage();

            this.unitOfWork.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
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
