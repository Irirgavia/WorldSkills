namespace WebAPI.ObjectMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;

    using BLL.DTO;

    using Models;

    public class ObjectMapperDTOModel
    {
        public static ScheduleElement ToModel(CompetitionDTO competitionDTO)
        {
            string dateFormat = "dd.MM.yyyy HH:mm";
            StringBuilder stringBuilder = new StringBuilder();
            var scheduleElement = new ScheduleElement()
            {
                Skill = competitionDTO.Skill.Name,
                DateOfBegin = competitionDTO.DateTimeBegin.ToShortDateString(),
                DateOfEnd = competitionDTO.DateTimeEnd.ToShortDateString()
            };
            foreach(var stage in competitionDTO.Stages)
            {
                var competitionStage = new ScheduleElement.CompetitionStage()
                {
                    Type = stage.TypeStage.ToString()
                };
                foreach(var task in stage.Tasks)
                {
                    var stageTask = new ScheduleElement.CompetitionStage.StageTask()
                    {
                        TaskDateOfBegin = task.DateTime.ToString(dateFormat)
                    };
                    var dateOfEnd = task.DateTime + task.Time;
                    stageTask.TaskDateOfEnd = dateOfEnd.ToString(dateFormat);
                    stageTask.IsActual = dateOfEnd < DateTime.Now;
                    //foreach(var address in task.Address)
                    stageTask.Addresses = task.Address.ToString();
                    competitionStage.Tasks.Add(stageTask);
                }
                scheduleElement.Stages.Add(competitionStage);
            }
            return scheduleElement;
        }

        /*public static IEnumerable<ResultsElement> ToModel(StageDTO stageDTO)
        {
            ICollection<ResultsElement> resultsElements = new List<ResultsElement>();
            var resultsElement = new ResultsElement();
            foreach(int participantId in stageDTO.Participants)
            {

            }
            return resultsElement;
        }*/
    }
}