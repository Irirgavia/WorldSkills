namespace BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;
    using BLL.Utilities;

    using DAL;
    using DAL.Entities.Account;
    using DAL.Entities.Competition;
    using DAL.UnitOfWorks;
    using DAL.UnitOfWorks.Interfaces;

    public class CompetitionService : IDisposable
    {
        private readonly ICompetitionUnitOfWork competitionUnitOfWork;

        public CompetitionService(string competitionConnection)
        {
            this.competitionUnitOfWork = new CompetitionUnitOfWork(competitionConnection);
        }

        public AnswerDTO CreateAnswer(
            int accountId,
            int taskId,
            string projectLink,
            string notes,
            string prizeTypeName = Constants.PrizeType.NonAwardWinning)
        {
            var prize = this.competitionUnitOfWork.PrizeRepository.Get(p => p.Name == prizeTypeName).FirstOrDefault();

            AnswerEntity answer;
            try
            {
                answer = this.competitionUnitOfWork.AnswerRepository.Create(
                    new AnswerEntity(accountId, new ResultEntity(prize.Id), taskId, projectLink, notes));

                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<AnswerEntity, AnswerDTO>.Map(answer);
        }

        public CompetitionDTO CreateCompetition(DateTime begin, DateTime end, string skill)
        {
            var skillEf = this.competitionUnitOfWork.SkillRepository.GetOrCreate(
                new SkillEntity(skill),
                s => s.Name == skill);

            var competition = this.competitionUnitOfWork.CompetitionRepository.Create(
                new CompetitionEntity(skillEf.Id, begin, end, new List<StageEntity>()));
            this.competitionUnitOfWork.SaveChanges();
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.Map(competition);
        }

        public AddressDTO CreateCompetitionAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes)
        {
            AddressEntity address;
            try
            {
                address = this.competitionUnitOfWork.AddressRepository.Create(
                    new AddressEntity(country, city, street, house, apartment, notes));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<AddressEntity, AddressDTO>.Map(address);
        }

        public PrizeDTO CreatePrize(string prizeName)
        {
            PrizeEntity prize;
            try
            {
                prize = this.competitionUnitOfWork.PrizeRepository.Create(new PrizeEntity(prizeName));
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<PrizeEntity, PrizeDTO>.Map(prize);
        }

        public SkillDTO CreateSkill(string skillName)
        {
            SkillEntity skill;
            try
            {
                skill = this.competitionUnitOfWork.SkillRepository.Create(new SkillEntity(skillName));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<SkillEntity, SkillDTO>.Map(skill);
        }

        public StageDTO CreateStage(int competitionId, int stageTypeId, ICollection<int> accounts)
        {
            StageEntity stage;
            try
            {
                stage = new StageEntity(competitionId, stageTypeId, new List<TaskEntity>(), accounts);
                this.competitionUnitOfWork.StageRepository.Create(stage);
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<StageEntity, StageDTO>.Map(stage);
        }

        public StageTypeDTO CreateStageType(string stageTypeName)
        {
            StageTypeEntity stageType;
            try
            {
                stageType = this.competitionUnitOfWork.StageTypeRepository.Create(new StageTypeEntity(stageTypeName));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<StageTypeEntity, StageTypeDTO>.Map(stageType);
        }

        public TaskDTO CreateTask(
            int stageId,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            IEnumerable<AddressDTO> addresses,
            IEnumerable<AnswerDTO> answers)
        {
            TaskEntity task;
            try
            {
                task = new TaskEntity(
                    stageId,
                    dateTime,
                    time,
                    description,
                    requirement,
                    ObjectMapper<AddressDTO, AddressEntity>.MapList(addresses).ToArray(),
                    ObjectMapper<AnswerDTO, AnswerEntity>.MapList(answers).ToArray());
                this.competitionUnitOfWork.TaskRepository.Create(task);
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return ObjectMapper<TaskEntity, TaskDTO>.Map(task);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<int> GetAccountIdsByStageId(int id)
        {
            return this.competitionUnitOfWork.StageRepository.Get(s => s.Id == id).FirstOrDefault()?.AccountIds;
        }

        public IEnumerable<CompetitionDTO> GetActualCompetitions()
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(c => c.DateTimeEnd >= DateTime.Now));
        }

        public AddressDTO GetAddressById(int id)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.Map(
                this.competitionUnitOfWork.AddressRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public IEnumerable<AddressDTO> GetAddressesByPlace(
            string country,
            string city,
            string street,
            string house,
            string apartments)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.MapList(
                this.competitionUnitOfWork.AddressRepository.GetAddressesByPlace(
                    country,
                    city,
                    street,
                    house,
                    apartments));
        }

        public IEnumerable<CompetitionDTO> GetAllCompetitions()
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.GetAll());
        }

        public IEnumerable<PrizeDTO> GetAllPrizes()
        {
            return ObjectMapper<PrizeEntity, PrizeDTO>.MapList(this.competitionUnitOfWork.PrizeRepository.GetAll());
        }

        public IEnumerable<SkillDTO> GetAllSkills()
        {
            return ObjectMapper<SkillEntity, SkillDTO>.MapList(this.competitionUnitOfWork.SkillRepository.GetAll());
        }

        public IEnumerable<StageTypeDTO> GetAllStageTypes()
        {
            return ObjectMapper<StageTypeEntity, StageTypeDTO>.MapList(
                this.competitionUnitOfWork.StageTypeRepository.GetAll());
        }

        public AnswerDTO GetAnswerById(int id)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.Map(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public IEnumerable<AnswerDTO> GetAnswersByAccountId(int id)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.MapList(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.AccountEntityId == id));
        }

        public IEnumerable<AnswerDTO> GetAnswersByPrizeId(int id)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.MapList(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.ResultEntity.PrizeEntityId == id));
        }

        public IEnumerable<AnswerDTO> GetAnswersByTaskAndMarkRangeAndPrizeType(
            int taskId,
            float beginRange = 0,
            float endRange = 0,
            string prizeTypeName = Constants.PrizeType.NonAwardWinning)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.MapList(
                this.competitionUnitOfWork.AnswerRepository.Get(
                    a => a.TaskEntityId == taskId && a.ResultEntity.Mark >= beginRange
                                                  && a.ResultEntity.Mark <= endRange
                                                  && a.ResultEntity.PrizeEntity.Name == prizeTypeName));
        }

        public IEnumerable<AnswerDTO> GetAnswersByTaskId(int id)
        {
            return ObjectMapper<AnswerEntity, AnswerDTO>.MapList(
                this.competitionUnitOfWork.AnswerRepository.Get(a => a.TaskEntityId == id));
        }

        public AddressDTO GetCompetitionAddressById(int id)
        {
            return ObjectMapper<AddressEntity, AddressDTO>.Map(
                this.competitionUnitOfWork.AddressRepository.Get(a => a.Id == id).FirstOrDefault());
        }

        public CompetitionDTO GetCompetitionById(int id)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.Map(
                this.competitionUnitOfWork.CompetitionRepository.Get(c => c.Id == id).FirstOrDefault());
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsByDateRange(DateTime begin, DateTime end)
        {
            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(
                    c => c.DateTimeBegin >= begin && c.DateTimeEnd <= end));
        }

        public IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int? year)
        {
            if (skill != null && year != null)
                return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                    this.competitionUnitOfWork.CompetitionRepository.Get(
                        c => c.SkillEntity.Name == skill
                          && (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year)
                          && (c.DateTimeEnd.Year == year + 1 || c.DateTimeEnd.Year == year)));

            if (skill != null)
                return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                    this.competitionUnitOfWork.CompetitionRepository.Get(c => c.SkillEntity.Name == skill));

            return ObjectMapper<CompetitionEntity, CompetitionDTO>.MapList(
                this.competitionUnitOfWork.CompetitionRepository.Get(
                    c => (c.DateTimeBegin.Year == year - 1 || c.DateTimeBegin.Year == year)
                      && (c.DateTimeEnd.Year == year + 1 || c.DateTimeEnd.Year == year)));
        }

        public PrizeDTO GetPrizeById(int id)
        {
            return ObjectMapper<PrizeEntity, PrizeDTO>.Map(
                this.competitionUnitOfWork.PrizeRepository.Get(p => p.Id == id).FirstOrDefault());
        }

        public ResultDTO GetResultById(int id)
        {
            return ObjectMapper<ResultEntity, ResultDTO>.Map(
                this.competitionUnitOfWork.ResultRepository.Get(r => r.Id == id).FirstOrDefault());
        }

        public SkillDTO GeTSkillById(int id)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(
                this.competitionUnitOfWork.SkillRepository.Get(s => s.Id == id).FirstOrDefault());
        }

        public SkillDTO GetSkillByName(string skill)
        {
            return ObjectMapper<SkillEntity, SkillDTO>.Map(
                this.competitionUnitOfWork.SkillRepository.Get(s => s.Name == skill).FirstOrDefault());
        }

        public StageDTO GetStageById(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.Map(
                this.competitionUnitOfWork.StageRepository.Get(s => s.Id == id).FirstOrDefault());
        }

        public IEnumerable<StageDTO> GetStageByStageTypeId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(s => s.StageTypeEntityId == id));
        }

        public IEnumerable<StageDTO> GetStages(int accountId)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(s => s.AccountIds.Contains(accountId)));
        }

        public IEnumerable<StageDTO> GetStagesByAccountId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(s => s.AccountIds.Contains(id)));
        }

        public IEnumerable<StageDTO> GetStagesByCompetitionId(int id)
        {
            return ObjectMapper<StageEntity, StageDTO>.MapList(
                this.competitionUnitOfWork.StageRepository.Get(s => s.CompetitionEntityId == id));
        }

        public IEnumerable<StageDTO> GetStagesBySkillAndYearAndTypeStage(string skill, int? year, string stageType)
        {
            var competitions = this.GetCompetitionsBySkillAndYear(skill, year);
            var stages = new List<StageDTO>();
            foreach (var competition in competitions)
            {
                foreach (var stage in competition.Stages)
                    if (stage.StageType.Name == stageType)
                        stages.Add(stage);
            }

            return stages;
        }

        public StageTypeDTO GetStageTypeById(int id)
        {
            return ObjectMapper<StageTypeEntity, StageTypeDTO>.Map(
                this.competitionUnitOfWork.StageTypeRepository.Get(s => s.Id == id).FirstOrDefault());
        }

        public StageTypeDTO GetStageTypeByName(string name)
        {
            return ObjectMapper<StageTypeEntity, StageTypeDTO>.Map(
                this.competitionUnitOfWork.StageTypeRepository.Get(s => s.Name == name).FirstOrDefault());
        }

        public TaskDTO GetTaskById(int id)
        {
            return ObjectMapper<TaskEntity, TaskDTO>.Map(
                this.competitionUnitOfWork.TaskRepository.Get(t => t.Id == id).FirstOrDefault());
        }

        public bool IsPrizeExist(string prizeName)
        {
            var checkPrize = this.competitionUnitOfWork.PrizeRepository.Get(s => s.Name == prizeName).FirstOrDefault();
            return checkPrize != null;
        }

        public bool IsSkillExist(string skillName)
        {
            var checkSkill = this.competitionUnitOfWork.SkillRepository.Get(s => s.Name == skillName).FirstOrDefault();
            return checkSkill != null;
        }

        public bool IsStageTypeExist(string stageTypeName)
        {
            var checkStageTypeName = this.competitionUnitOfWork.StageTypeRepository.Get(s => s.Name == stageTypeName)
                                         .FirstOrDefault();
            return checkStageTypeName != null;
        }

        public bool RegisterAccountOnCompetitionStage(int competitionId, string stageType, int accountId)
        {
            try
            {
                var stage = this.competitionUnitOfWork.StageRepository.Get(
                                    s => s.CompetitionEntityId == competitionId && s.StageTypeEntity.Name == stageType)
                                .FirstOrDefault();
                stage.AccountIds.Add(accountId);
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveAccountFromStage(int stageId, int accountId)
        {
            try
            {
                var stage = this.competitionUnitOfWork.StageRepository.Get(s => s.Id == stageId).FirstOrDefault();
                stage.AccountIds.Remove(accountId);
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateAnswer(int accountId, int taskId, string notes)
        {
            try
            {
                var answer = this.competitionUnitOfWork.AnswerRepository.Get(
                    a => a.TaskEntityId == taskId && a.AccountEntityId == accountId).FirstOrDefault();

                answer.Notes = notes;
                this.competitionUnitOfWork.AnswerRepository.Update(answer);
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCompetition(CompetitionDTO competition)
        {
            try
            {
                this.competitionUnitOfWork.CompetitionRepository.Update(
                    ObjectMapper<CompetitionDTO, CompetitionEntity>.Map(competition));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdatePrize(PrizeDTO prize)
        {
            try
            {
                this.competitionUnitOfWork.PrizeRepository.Update(ObjectMapper<PrizeDTO, PrizeEntity>.Map(prize));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateResult(ResultDTO result)
        {
            try
            {
                this.competitionUnitOfWork.ResultRepository.Update(ObjectMapper<ResultDTO, ResultEntity>.Map(result));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateSkill(SkillDTO skill)
        {
            try
            {
                this.competitionUnitOfWork.SkillRepository.Update(ObjectMapper<SkillDTO, SkillEntity>.Map(skill));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateStage(StageDTO stage)
        {
            try
            {
                this.competitionUnitOfWork.StageRepository.Update(ObjectMapper<StageDTO, StageEntity>.Map(stage));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateStageType(StageTypeDTO stageType)
        {
            try
            {
                this.competitionUnitOfWork.StageTypeRepository.Update(
                    ObjectMapper<StageTypeDTO, StageTypeEntity>.Map(stageType));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateTask(TaskDTO task)
        {
            try
            {
                this.competitionUnitOfWork.TaskRepository.Update(ObjectMapper<TaskDTO, TaskEntity>.Map(task));
                this.competitionUnitOfWork.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) this.competitionUnitOfWork?.Dispose();
        }
    }
}