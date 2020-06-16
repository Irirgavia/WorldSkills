namespace WebAPI.ObjectMapper
{
    using BLL.DTO.Competition;
    using BLL.Services.Interfaces;
    using Models.ResponseModels.ForParticipant;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectMapperDTOModelForParticipant
    {
        static string dateFormat = "yyyy-MM-ddThh:mm";
        public static CompetitionForTaskResponseModel ToCompetitionForParticipantResponseModel(StageDTO stageDTO)
        {
            var competitionForParticipantResponseModel = new CompetitionForTaskResponseModel()
            {
                Skill = stageDTO.CompetitionId.ToString(),
                DateOfBegin = stageDTO.CompetitionId.ToString(),
                DateOfEnd = stageDTO.CompetitionId.ToString()
            };
            var stage = new StageForTaskResponseModel()
            {
                Type = stageDTO.StageType.Name
            };
            foreach (var taskDTO in stageDTO.Tasks)
            {
                var task = new TaskForTaskResponseModel()
                {
                    Description = taskDTO.Description,
                    TaskDateOfBegin = taskDTO.DateTimeBegin.ToString(dateFormat)
                };
                var dateOfEnd = taskDTO.DateTimeBegin + taskDTO.DurationTime;
                task.TaskDateOfEnd = dateOfEnd.ToString(dateFormat);
                task.IsActual = dateOfEnd < DateTime.Now;
                stage.Tasks.Add(task);
            }
            return competitionForParticipantResponseModel;
        }

        public static IEnumerable<ResultForParticipantResponseModel> ToResultForParticipantResponseModel(StageDTO stageDTO, int userId, IAdministratorService adminService)
        {
            string skill = adminService.GetCompetitionById(stageDTO.CompetitionId).Skill.Name;
            ICollection<ResultForParticipantResponseModel> results = new List<ResultForParticipantResponseModel>();
            foreach (var task in stageDTO.Tasks)
            {
                var resultForParticipantResponseModel = new ResultForParticipantResponseModel()
                {
                    Skill = skill,
                    Stage = stageDTO.StageType.Name,
                    Date = task.DateTimeBegin.ToString(dateFormat)
                };
                var answer = task.Answers.FirstOrDefault(a => a.AccountId == userId);
                resultForParticipantResponseModel.Mark = answer.Result.Mark;
                results.Add(resultForParticipantResponseModel);
            }
            return results;
        }
    }
}