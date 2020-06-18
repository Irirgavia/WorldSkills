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
        /// Get by judge Id what answer he should rate
        /// </summary>
        /// <param name="judgeId"></param>
        /// <returns></returns>
        [Route("api/answer")]
        public IHttpActionResult Receive([FromBody] UserIdRequestModel judgeId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            ICollection<CompetitionForAnswerResponseModel> answerForJudgeModels = new List<CompetitionForAnswerResponseModel>();
            var competitionService = ServiceProvider.GetCompetitionService();
            try
            {
                var stages = competitionService.GetStagesByAccountId(judgeId.id);
                foreach (var stage in stages)
                {
                    answerForJudgeModels.Add(ObjectMapperDTOModelForJudge.ToAnswerForJudgeResponseModel(stage));
                }
                return Json(answerForJudgeModels);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/answer/save")]
        public IHttpActionResult Save([FromBody] AnswerSaveRequestModel parameters)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var competitionService = ServiceProvider.GetCompetitionService();
            try
            {
                competitionService.CreateAnswer(parameters.participantId, parameters.taskId, parameters.projectLink, null);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
