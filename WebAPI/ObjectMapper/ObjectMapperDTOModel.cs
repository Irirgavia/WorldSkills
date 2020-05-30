namespace WebAPI.ObjectMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using BLL.DTO;
    using BLL.Services;
    using Models.ResponseModels;

    public class ObjectMapperDTOModel
    {
        static string dateFormat = "dd.MM.yyyy HH:mm";
        public static ScheduleElementResponseModel ToModel(CompetitionDTO competitionDTO)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var scheduleElement = new ScheduleElementResponseModel()
            {
                Skill = competitionDTO.Skill.Name,
                DateOfBegin = competitionDTO.DateTimeBegin.ToShortDateString(),
                DateOfEnd = competitionDTO.DateTimeEnd.ToShortDateString()
            };
            foreach(var stage in competitionDTO.Stages)
            {
                var competitionStage = new ScheduleElementResponseModel.CompetitionStage()
                {
                    Type = stage.TypeStageDto.ToString()
                };
                foreach(var task in stage.Tasks)
                {
                    var stageTask = new ScheduleElementResponseModel.CompetitionStage.StageTask()
                    {
                        TaskDateOfBegin = task.DateTime.ToString(dateFormat)
                    };
                    var dateOfEnd = task.DateTime + task.Time;
                    stageTask.TaskDateOfEnd = dateOfEnd.ToString(dateFormat);
                    stageTask.IsActual = dateOfEnd < DateTime.Now;
                    foreach(var address in task.Addresses)
                    stageTask.Addresses = task.Addresses.ToString();
                    competitionStage.Tasks.Add(stageTask);
                }
                scheduleElement.Stages.Add(competitionStage);
            }
            return scheduleElement;
        }

        /*public static IEnumerable<ResultsElement> ToModel(CompetitionDTO competitionDTO, string stageType)
        {
            AdministratorService administratorService = new AdministratorService("CompetitionContext");
            ICollection<ResultsElement> resultsElements = new List<ResultsElement>();
            var resultsElement = new ResultsElement();
            var stageDTO = competitionDTO.Stages.FirstOrDefault(x => x.TypeStage.ToString() == stageType);
            foreach(TaskDTO task in stageDTO.Tasks)
            {
                foreach(AnswerDTO answerDTO in task.Answers)
                {
                    answerDTO.Result.Mark()
                }
            }
            return resultsElement;
        }*/

        public static PersonalDataResponseModel ToModel(UserDTO userDTO)
        {
            PersonalDataResponseModel personalData = new PersonalDataResponseModel()
            {
                Surname = userDTO.Surname,
                Name = userDTO.Name,
                Patronymic = userDTO.Patronymic,
                Birthday = userDTO.Birthday.ToString(dateFormat),
                Mail = userDTO.Mail,
                Telephone = userDTO.Telephone,
                Awards = userDTO.Awards
            };
            return personalData;
        }

        public static UserResponseModel UserToModel(UserDTO userDTO)
        {
            UserResponseModel personalData = new UserResponseModel()
            {
                Id = userDTO.Id,
                Login = userDTO.Login,
                Role = "participant",
                Status = "Success"
            };
            return personalData;
        }
    }
}