using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.RequestModels;
using WebAPI.Models.ResponseModels;

namespace WebAPI.Controllers
{
    public class AnswerController : ApiController
    {
        public IHttpActionResult Get([FromBody] int judgeId)
        {
            ICollection<AnswerForJudgeResponseModel> AnswerForJudgeModels = new List<AnswerForJudgeResponseModel>();
            /*var guestService = new GuestService("CompetitionContext");
            var competitions = guestService.GetActualCompetitions();
            foreach(var competition in competitions)
            {
                scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
            }*/
            return Json(/*scheduleElements*/ Test.TestDataForSchedule());
        }

        public IHttpActionResult Save([FromBody] AnswerSaveRequestModel parameters)
        {
            ICollection<AnswerForJudgeResponseModel> AnswerForJudgeModels = new List<AnswerForJudgeResponseModel>();
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
