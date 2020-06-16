using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.RequestModels;

namespace WebAPI.Controllers
{
    using ServiceProvider;

    public class MarkController : ApiController
    {
        [Route("api/mark/save")]
        public IHttpActionResult Save([FromBody] MarkSaveRequestModel parameters)
        {
            var competitionService = ServiceProvider.GetCompetitionService();
            var answer = competitionService.GetAnswerById(parameters.answerId);
            var result = answer.Result;
            result.Mark = parameters.mark;
            competitionService.UpdateResult(result);
            return Ok();
        }
    }
}
