namespace WebAPI.ObjectMapper
{
    using BLL.DTO.Competition;
    using Models.ResponseModels.ForParticipant;
    using System;

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
    }
}