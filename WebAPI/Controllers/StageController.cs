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
    public class StageController : ApiController
    {
        public IHttpActionResult Get()
        {

            return Json(Test.TestDataForStages());
        }

        [Route("api/stage/save")]
        public IHttpActionResult Save([FromBody] StageSaveRequestModel parameters)
        {
            var competitionService = ServiceProvider.GetCompetitionService();
            try
            {
                var stageType = competitionService.GetStageTypeByName(parameters.stagetype);
                if (parameters.id == -1)
                {
                    competitionService.CreateStage(parameters.competitionId, stageType.Id, new List<int>());
                }
                else
                {
                    var stage = competitionService.GetStageById(parameters.id);
                    if (stage == null)
                    {
                        competitionService.CreateStage(parameters.competitionId, stageType.Id, new List<int>());
                    }
                    else
                    {
                        stage.StageType = stageType;
                        competitionService.UpdateStage(stage);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
