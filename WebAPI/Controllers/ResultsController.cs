namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models.ResponseModels;

    public class ResultsController : ApiController
    {
        //"http://localhost:49263/api/results?skill=skill&stage=stage&year=2020"
        //[Route(("skill={skill}&stage={stage}&year={year:range(2000, 3000)}"))]
        public IHttpActionResult Get([FromUri]string skill = null, [FromUri] string stage = null, [FromUri] int? year = null, [FromUri] bool isCSV = false)
        {
            if (skill == null && stage == null && year == null)
                return BadRequest();
            ICollection<ResultsElementResponseModel> resultsElements = new List<ResultsElementResponseModel>();

            return Json(/*Test.TestDataForResults(skill, stage, year)*/0);
        }

        [Route("api/results/participant")]
        public IHttpActionResult GetResultsByParticipant([FromBody] int participantId)
        {
            ICollection<ResultForParticipantResponseModel> resultsElements = new List<ResultForParticipantResponseModel>();

            return Json(/*Test.TestDataForResults(skill, stage, year)*/0);
        }

        [Route("api/results/trainer")]
        public IHttpActionResult GetResultsByTrainer([FromBody] int trainerId)
        {
            ICollection<ResultForTrainerResponseModel> resultsElements = new List<ResultForTrainerResponseModel>();

            return Json(/*Test.TestDataForResults(skill, stage, year)*/0);
        }
    }
}
