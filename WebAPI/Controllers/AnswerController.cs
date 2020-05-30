using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.RequestModels;
using WebAPI.Models.ResponseModels;
using WebAPI.ObjectMapper;

namespace WebAPI.Controllers
{
    public class AnswerController : ApiController
    {
        public IHttpActionResult Get([FromBody] int judgeId)
        {
            ICollection<AnswerForJudgeResponseModel> answerForJudgeModels = new List<AnswerForJudgeResponseModel>();
            using (var participantService = new BLL.Services.ParticipantService("CompetitionContext"))
            {
                using (var adminService = new BLL.Services.AdministratorService("CompetitionContext"))
                {
                    var participant = adminService.GetParticipantById(judgeId);
                    var stages = participantService.GetStages(participant);
                    foreach(var stage in stages)
                    {
                        answerForJudgeModels.Add(ObjectMapperDTOModel.ToAnswerForJudgeResponseModel(stage));
                    }
                }
            }
            return Json(answerForJudgeModels);
        }

        public IHttpActionResult Save([FromBody] AnswerSaveRequestModel parameters)
        {
            return BadRequest();
        }
    }
}
