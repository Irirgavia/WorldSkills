namespace BLL.Services.Interfaces
{
    using System;
    using System.Collections.Generic;

    using BLL.DTO.Account;
    using BLL.DTO.Competition;

    using DAL;

    public interface ICompetitionService : IDisposable
    {
        AnswerDTO CreateAnswer(
            int accountId,
            int taskId,
            string projectLink,
            string notes,
            string prizeTypeName = Constants.PrizeType.NonAwardWinning);

        CompetitionDTO CreateCompetition(DateTime begin, DateTime end, string skill);

        AddressDTO CreateCompetitionAddress(
            string country,
            string city,
            string street,
            string house,
            string apartment,
            string notes);

        PrizeDTO CreatePrize(string prizeName);

        SkillDTO CreateSkill(string skillName);

        StageDTO CreateStage(int competitionId, int stageTypeId, IList<int> accounts);

        StageTypeDTO CreateStageType(string stageTypeName);

        TaskDTO CreateTask(
            int stageId,
            DateTime dateTime,
            TimeSpan time,
            string description,
            string requirement,
            IEnumerable<AddressDTO> addresses,
            IEnumerable<AnswerDTO> answers);


        IEnumerable<int> GetAccountIdsByStageId(int id);

        IEnumerable<CompetitionDTO> GetActualCompetitions();

        AddressDTO GetAddressById(int id);

        IEnumerable<AddressDTO> GetAddressesByPlace(
            string country,
            string city,
            string street,
            string house,
            string apartments);

        IEnumerable<CompetitionDTO> GetAllCompetitions();

        IEnumerable<PrizeDTO> GetAllPrizes();

        IEnumerable<SkillDTO> GetAllSkills();

        IEnumerable<StageTypeDTO> GetAllStageTypes();

        AnswerDTO GetAnswerById(int id);

        IEnumerable<AnswerDTO> GetAnswersByAccountId(int id);

        IEnumerable<AnswerDTO> GetAnswersByPrizeId(int id);

        IEnumerable<AnswerDTO> GetAnswersByTaskAndMarkRangeAndPrizeType(
            int taskId,
            float beginRange = 0,
            float endRange = 0,
            string prizeTypeName = Constants.PrizeType.NonAwardWinning);

        IEnumerable<AnswerDTO> GetAnswersByTaskId(int id);

        AddressDTO GetCompetitionAddressById(int id);

        CompetitionDTO GetCompetitionById(int id);

        IEnumerable<CompetitionDTO> GetCompetitionsByDateRange(DateTime begin, DateTime end);

        IEnumerable<CompetitionDTO> GetCompetitionsBySkillAndYear(string skill, int? year);

        IEnumerable<CompetitionDTO> GetCompetitionsForRegistration(string stageTypeName);

        PrizeDTO GetPrizeById(int id);

        ResultDTO GetResultById(int id);

        SkillDTO GeTSkillById(int id);

        SkillDTO GetSkillByName(string skill);

        StageDTO GetStageById(int id);

        IEnumerable<StageDTO> GetStageByStageTypeId(int id);

        IEnumerable<StageDTO> GetStages(int accountId);

        IEnumerable<StageDTO> GetStagesByAccountId(int id);

        IEnumerable<StageDTO> GetStagesByCompetitionId(int id);

        IEnumerable<StageDTO> GetStagesBySkillAndYearAndTypeStage(string skill, int? year, string stageType);

        StageTypeDTO GetStageTypeById(int id);

        StageTypeDTO GetStageTypeByName(string name);

        TaskDTO GetTaskById(int id);

        bool IsPrizeExist(string prizeName);

        bool IsSkillExist(string skillName);

        bool IsStageTypeExist(string stageTypeName);

        bool RegisterAccountOnCompetitionStage(int competitionId, string stageType, int accountId);

        bool RemoveAccountFromStage(int stageId, int accountId);

        bool UpdateAnswer(int accountId, int taskId, string notes);

        bool UpdateCompetition(CompetitionDTO competition);

        bool UpdatePrize(PrizeDTO prize);

        bool UpdateResult(ResultDTO result);

        bool UpdateSkill(SkillDTO skill);

        bool UpdateStage(StageDTO stage);

        bool UpdateStageType(StageTypeDTO stageType);

        bool UpdateTask(TaskDTO task);
    }
}