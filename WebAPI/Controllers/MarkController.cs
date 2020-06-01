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
        public IHttpActionResult Save([FromBody] MarkSaveRequestModel parameters)
        {
            var judgeService = ServiceProvider.GetJudgeService();
            judgeService.RateAnswer(parameters.answerId, parameters.mark, null);
            return Ok();
        }
    }
}
