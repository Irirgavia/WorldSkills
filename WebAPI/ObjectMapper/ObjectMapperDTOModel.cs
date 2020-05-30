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
    using WebAPI.Models.RequestModels;

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
                    foreach (var address in task.Addresses)
                    {
                        stringBuilder.Append(address);
                        stringBuilder.Append(", ");
                    }
                    stageTask.Addresses = stringBuilder.ToString();
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

        public static UserResponseModel UserToModel(UserDTO userDTO, bool isPasswordValid)
        {
            if (userDTO == null)
            {
                return new UserResponseModel()
                {
                    Id = -1,
                    Login = "",
                    Role = "",
                    Status = "NotFound"
                };
            }

            if (isPasswordValid)
            {
                return new UserResponseModel()
                {
                    Id = userDTO.Id,
                    Login = userDTO.Login,
                    Role = "participant",
                    Status = "Success"
                };
            }
            else
            {
                return new UserResponseModel()
                {
                    Id = -1,
                    Login = "",
                    Role = "",
                    Status = "WrongPassword"
                };
            }
        }

        public static PersonalDataResponseModel ToPersonalDataResponseModel(ParticipantDTO participantDTO)
        {
            PersonalDataResponseModel personalDataResponseModel = new PersonalDataResponseModel()
            {
                Surname = participantDTO.User.Surname,
                Name = participantDTO.User.Name,
                Patronymic = participantDTO.User.Patronymic,
                Birthday = participantDTO.User.Birthday.ToString(dateFormat),
                Telephone = participantDTO.User.Telephone,
                Mail = participantDTO.User.Mail,
                Awards = participantDTO.User.Awards,
                AddressId = participantDTO.Address.Id,
                Country = participantDTO.Address.Country,
                City = participantDTO.Address.City,
                Street = participantDTO.Address.Street,
                House = participantDTO.Address.House
            };
            return personalDataResponseModel;
        }

        public static AnswerForJudgeResponseModel ToAnswerForJudgeResponseModel(StageDTO stageDTO)
        {
            AnswerForJudgeResponseModel answerForJudgeResponseModel = new AnswerForJudgeResponseModel()
            {
                Skill = stageDTO.CompetitionId.ToString(),
                DateOfBegin = stageDTO.CompetitionId.ToString(),
                DateOfEnd = stageDTO.CompetitionId.ToString()
            };
            var stage = new AnswerForJudgeResponseModel.CompetitionStage()
            {
                Type = stageDTO.TypeStageDto.ToString()
            };
            foreach(var taskDTO in stageDTO.Tasks)
            {
                var task = new AnswerForJudgeResponseModel.CompetitionStage.StageTask()
                {
                    Description = taskDTO.Description,
                    TaskDateOfBegin = taskDTO.DateTime.ToString(),
                    TaskDateOfEnd = (taskDTO.DateTime + taskDTO.Time).ToString()
                };
                foreach (var answerDTO in taskDTO.Answers)
                {
                    var answer = new AnswerForJudgeResponseModel.CompetitionStage.StageTask.TaskAnswer()
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