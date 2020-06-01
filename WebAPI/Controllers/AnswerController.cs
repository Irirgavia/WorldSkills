namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using WebAPI.Models.RequestModels;
    using WebAPI.Models.ResponseModels.ForJudge;
    using WebAPI.ObjectMapper;
    using WebAPI.ServiceProvider;

    public class AnswerController : ApiController
    {
        /// <summary>
        /// Get by judge what answer he should rate
        /// </summary>
        /// <param name="judgeId"></param>
        /// <returns></returns>
        public IHttpActionResult Get([FromBody] int judgeId)
        {
            ICollection<CompetitionForAnswerResponseModel> answerForJudgeModels = new List<CompetitionForAnswerResponseModel>();
            var adminService = ServiceProvider.GetAdministratorService();
            var stages = adminService.GetStagesByAccountId(judgeId);
            foreach (var stage in stages)
            {
                answerForJudgeModels.Add(ObjectMapperDTOModelForJudge.ToAnswerForJudgeResponseModel(stage));
            }
            return Json(answerForJudgeModels);
        }

        public IHttpActionResult Save([FromBody] AnswerSaveRequestModel parameters)
        {
            return BadRequest();
        }
    }
}
