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

        public void CreateCompetition(
            SkillDTO skill, 
            DateTime begin, 
            DateTime end, 
            ICollection<StageDTO> stages)
        {
            var stagesEntities = new List<StageEntity>();
            foreach (var stage in stages)
            {
                stagesEntities.Add(ObjectMapper.ToDLO(stage));
            }

            this.unitOfWork.CompetitionRepository.CreateCompetition(ObjectMapper.ToDLO(skill), begin, end, stagesEntities);
            this.unitOfWork.SaveChanges();
        }

        public ICollection<CompetitionDTO> GetAllCompetitions()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.CompetitionRepository.GetAll());
        }

        public CompetitionDTO GetCompetition(int id)
        {
            return ObjectMapper.ToBLO(this.unitOfWork.CompetitionRepository.GetCompetitionById(id));
        }

        public void CreateStage(
            CompetitionDTO competition, 
            TypeStage typeStage,
            ICollection<TaskDTO> tasks,
            ICollection<ParticipantDTO> participants,
            ICollection<JudgeDTO> judges,
            ICollection<AdministratorDTO> administrators)
        {
            var tasksEntities = new List<TaskEntity>();
            foreach (var task in tasks)
            {
                tasksEntities.Add(ObjectMapper.ToDLO(task));
            }

            var participantsEntities = new List<ParticipantEntity>();
            foreach (var participant in participants)
            {
                participantsEntities.Add(ObjectMapper.ToDLO(participant));
            }

            var judgesEntities = new List<JudgeEntity>();
            foreach (var judge in judges)
            {
                judgesEntities.Add(ObjectMapper.ToDLO(judge));
            }

            var administratorsEntities = new List<AdministratorEntity>();
            foreach (var administrator in administrators)
            {
                administratorsEntities.Add(ObjectMapper.ToDLO(administrator));
            }

            this.unitOfWork.StageRepository.CreateStage(
                ObjectMapper.ToDLO(competition),
                typeStage,
                tasksEntities,
                participantsEntities,
                judgesEntities,
                administratorsEntities);

            this.unitOfWork.SaveChanges();
        }

        public ICollection<StageDTO> GetAllStages()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.StageRepository.GetAll());
        }


        public void CreateUser(
            string login,
            string password,
            string surname,
            string name,
            string patronymic,
            DateTime birthday,
            string photo,
            string mail,
            string telephone,
            string awards)
        {
            this.unitOfWork.UserRepository.CreateUser(login, password, surname, name, patronymic, birthday, photo, mail, telephone, awards);

            this.unitOfWork.SaveChanges();
        }

        public ICollection<UserDTO> GetAllUsers()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.UserRepository.GetAll());
        }

        public void CreateAdministrator(UserDTO user, ICollection<StageDTO> stages)
        {
            var stagesEntity = new List<StageEntity>();
            foreach (var stage in stages)
            {
                stagesEntity.Add(ObjectMapper.ToDLO(stage));
            }

            this.unitOfWork.AdministratorRepository.CreateAdministrator(ObjectMapper.ToDLO(user), stagesEntity);

            this.unitOfWork.SaveChanges();
        }

        public ICollection<AdministratorDTO> GetAllAdministrators()
        {
            return ObjectMapper.ToBLOList(this.unitOfWork.AdministratorRepository.GetAll());
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
