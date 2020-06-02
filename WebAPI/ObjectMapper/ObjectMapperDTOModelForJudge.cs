namespace WebAPI.ObjectMapper
{
    using BLL.DTO.Competition;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using WebAPI.Models.ResponseModels.ForJudge;

    public static class ObjectMapperDTOModelForJudge
    {
        static string dateFormat = "yyyy-MM-ddThh:mm";
        public static CompetitionForAnswerResponseModel ToAnswerForJudgeResponseModel(StageDTO stageDTO)
        {
            CompetitionForAnswerResponseModel answerForJudgeResponseModel = new CompetitionForAnswerResponseModel()
            {
                Skill = stageDTO.CompetitionId.ToString(),
                DateOfBegin = stageDTO.CompetitionId.ToString(),
                DateOfEnd = stageDTO.CompetitionId.ToString()
            };
            var stage = new StageForAnswerResponseModel()
            {
                Type = stageDTO.StageType.Name
            };
            foreach (var taskDTO in stageDTO.Tasks)
            {
                var task = new TaskForAnswerResponseModel()
                {
                    Description = taskDTO.Description,
                    TaskDateOfBegin = taskDTO.DateTimeBegin.ToString(dateFormat),
                    TaskDateOfEnd = (taskDTO.DateTimeBegin + taskDTO.DurationTime).ToString(dateFormat)
                };
                foreach (var answerDTO in taskDTO.Answers)
                {
                    var answer = new AnswerForAnswerResponseModel()
                    {
                        Id = answerDTO.Id,
                        Link = answerDTO.ProjectLink
                    };
                    task.Answers.Add(answer);
                }
                stage.Tasks.Add(task);
            }
            return answerForJudgeResponseModel;
        }
    }
}