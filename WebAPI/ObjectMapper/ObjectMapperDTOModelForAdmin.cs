namespace WebAPI.ObjectMapper
{
    using Models.ResponseModels.ForAdmin;
    using BLL.DTO.Competition;
    using System;
    using System.Text;

    public class ObjectMapperDTOModelForAdmin
    {
        static string dateFormat = "yyyy-MM-ddThh:mm";
        public static CompetitionResponseModel ToCompetitionForAdminResponseModel(CompetitionDTO competitionDTO)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var competitionForAdminResponseModel = new CompetitionResponseModel()
            {
                Id = competitionDTO.Id,
                Skill = competitionDTO.Id.ToString(),
                DateOfBegin = competitionDTO.DateTimeBegin.ToString(dateFormat),
                DateOfEnd = competitionDTO.DateTimeEnd.ToString(dateFormat)
            };
            foreach (var stageDTO in competitionDTO.Stages)
            {
                var stage = new StageResponseModel()
                {
                    Id = stageDTO.Id,
                    Type = stageDTO.StageType.Name
                };
                foreach (var taskDTO in stageDTO.Tasks)
                {
                    var task = new TaskResponseModel()
                    {
                        Id = taskDTO.Id,
                        Description = taskDTO.Description,
                        TaskDateOfBegin = taskDTO.DateTimeBegin.ToString(dateFormat)
                    };
                    var dateOfEnd = taskDTO.DateTimeBegin + taskDTO.DurationTime;
                    task.TaskDateOfEnd = dateOfEnd.ToString(dateFormat);
                    task.IsActual = dateOfEnd < DateTime.Now;
                    foreach(var address in taskDTO.Addresses)
                    {
                        stringBuilder.Append(address + "; ");
                    }
                    task.Addresses = stringBuilder.ToString();
                    stage.Tasks.Add(task);
                }
                competitionForAdminResponseModel.Stages.Add(stage);
            }
            return competitionForAdminResponseModel;
        }
    }
}