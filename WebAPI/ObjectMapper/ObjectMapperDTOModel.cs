namespace WebAPI.ObjectMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using BLL.DTO.Competition;
    using BLL.DTO.Account;
    using BLL.Services.Interfaces;
    using Models.ResponseModels;
    using Models.RequestModels;
    using BLL.DTO.NotificationSystem;
    using BLL.Services;

    public class ObjectMapperDTOModel
    {
        static string dateFormat = "yyyy-MM-ddThh:mm";
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
                    Type = stage.StageType.Name
                };
                foreach(var task in stage.Tasks)
                {
                    var stageTask = new ScheduleElementResponseModel.CompetitionStage.StageTask()
                    {
                        TaskDateOfBegin = task.DateTimeBegin.ToString(dateFormat)
                    };
                    var dateOfEnd = task.DateTimeBegin + task.DurationTime;
                    stageTask.TaskDateOfEnd = dateOfEnd.ToString(dateFormat);
                    stageTask.IsActual = dateOfEnd < DateTime.Now;
                    foreach (var address in task.Addresses)
                    {
                        stringBuilder.Append(address);
                        stringBuilder.Append("; ");
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

        public static PersonalDataResponseModel ToPersonalDataResponseModel(AccountDTO accountDTO)
        {
            PersonalDataResponseModel personalData = new PersonalDataResponseModel()
            {
                Surname = accountDTO.PersonalData.Surname,
                Name = accountDTO.PersonalData.Name,
                Patronymic = accountDTO.PersonalData.Patronymic,
                Birthday = accountDTO.PersonalData.Birthday.ToString(dateFormat),
                Mail = accountDTO.PersonalData.Mail,
                Telephone = accountDTO.PersonalData.Telephone,
                AddressId = accountDTO.PersonalData.Address.Id,
                Country = accountDTO.PersonalData.Address.Country,
                City = accountDTO.PersonalData.Address.City,
                Street = accountDTO.PersonalData.Address.Street,
                House = accountDTO.PersonalData.Address.House,
            };
            return personalData;
        }

        public static UserResponseModel AccountToModel(AccountDTO accountDTO, bool isPasswordValid, int unreadNotificationAmount)
        {
            if (accountDTO == null)
            {
                return new UserResponseModel()
                {
                    Id = -1,
                    Login = "",
                    Role = "",
                    Status = "NotFound", 
                    UnreadNotificationAmount = 0
                };
            }

            if (isPasswordValid)
            {
                return new UserResponseModel()
                {
                    Id = accountDTO.Id,
                    Login = accountDTO.Credentials.Login,
                    Role = accountDTO.Credentials.Role.Name,
                    Status = "Success",
                    UnreadNotificationAmount = unreadNotificationAmount
                };
            }
            else
            {
                return new UserResponseModel()
                {
                    Id = -1,
                    Login = "",
                    Role = "",
                    Status = "WrongPassword",
                    UnreadNotificationAmount = 0
                };
            }
        }

        public static DateTime ParseToDateTime(string str)
        {
            //2017-06-01T08:30
            char[] delimiters = { '-', 'T', ':' };
            string[] splitDate = str.Split(delimiters);
            int day = int.Parse(splitDate[2]);
            int month = int.Parse(splitDate[1]);
            int year = int.Parse(splitDate[0]);
            if (splitDate.Length == 3)
            { return new DateTime(year, month, day); }
            else
            {
                int hours = int.Parse(splitDate[3]);
                int minutes = int.Parse(splitDate[4]);
                DateTime dateTime = new DateTime(year, month, day, hours, minutes, 0);
                return dateTime;
            }
        }

        public static NotificationResponseModel ToModel(NotificationDTO notificationDTO)
        {
            var notificationResponseModel = new NotificationResponseModel()
            {
                Id = notificationDTO.Id,
                IsRead = notificationDTO.IsRead,
                Subject = notificationDTO.Mail.Subject,
                Message = notificationDTO.Mail.Body
            };
            return notificationResponseModel;
        }
        public static ResultsElementResponseModel ToResultsElementResponseModel(CompetitionDTO competitionDTO, string stage, IAccountService accountService)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var resultElement = new ResultsElementResponseModel()
            {
                Skill = competitionDTO.Skill.Name,
                DateOfBegin = competitionDTO.DateTimeBegin.ToShortDateString(),
                DateOfEnd = competitionDTO.DateTimeEnd.ToShortDateString()
            };
            foreach (var stageDTO in competitionDTO.Stages)
            {
                if ((stage != "All" && stageDTO.StageType.Name == stage) || stage == "All")
                {
                    var resultsStage = new ResultsStage()
                    {
                        Type = stageDTO.StageType.Name
                    };
                    foreach (var task in stageDTO.Tasks)
                    {
                        foreach (var answer in task.Answers)
                        {
                            var result = new ResultsResultRecords()
                            {
                                Mark = answer.Result.Mark
                            };
                            var participant = accountService.GetAccountById(answer.AccountId);
                            string participantFullName = $"{participant.PersonalData.Surname} {participant.PersonalData.Name} {participant.PersonalData.Patronymic}";
                            result.Participant = participantFullName;
                            resultsStage.ResultRecords.Add(result);
                        }
                    }
                    resultElement.Stages.Add(resultsStage);
                }
            }
            return resultElement;
        }
    }
}