using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AnswerController : ApiController
    {
        public IHttpActionResult Get([FromBody] int judgeId)
        {
            ICollection<AnswerForJudgeModel> AnswerForJudgeModels = new List<AnswerForJudgeModel>();
            /*var guestService = new GuestService("CompetitionContext");
            var competitions = guestService.GetActualCompetitions();
            foreach(var competition in competitions)
            {
                scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
            }*/
            return Json(/*scheduleElements*/ Test.TestDataForSchedule());
        }

        public IHttpActionResult Save([FromBody] int taskId, [FromBody] int participantId, [FromBody] string projectLink)
        {
            ICollection<AnswerForJudgeModel> AnswerForJudgeModels = new List<AnswerForJudgeModel>();
            /*var guestService = new GuestService("CompetitionContext");
            var competitions = guestService.GetActualCompetitions();
            foreach(var competition in competitions)
            {
                scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
            }*/
            return Json(/*scheduleElements*/ Test.TestDataForSchedule());
        }
    }
}
