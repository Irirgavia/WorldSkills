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

            return BadRequest();
        }

        [Route("api/results/participant")]
        public IHttpActionResult GetResultsByParticipant([FromBody] int participantId)
        {
            ICollection<Models.ResponseModels.ForParticipant.ResultForParticipantResponseModel> resultsElements = new List<Models.ResponseModels.ForParticipant.ResultForParticipantResponseModel>();

            return BadRequest();
        }

        [Route("api/results/trainer")]
        public IHttpActionResult GetResultsByTrainer([FromBody] int trainerId)
        {
            ICollection<Models.ResponseModels.ForTrainer.ResultForTrainerResponseModel> resultsElements = new List<Models.ResponseModels.ForTrainer.ResultForTrainerResponseModel>();

            return BadRequest();
        }
    }
}
