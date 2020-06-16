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
            var adminService = ServiceProvider.GetAdministratorService();
            try
            {
                var stageType = adminService.GetStageTypeByName(parameters.stagetype);
                if (parameters.id == -1)
                {
                    adminService.CreateStage(parameters.competitionId, stageType.Id, new List<int>());
                }
                else
                {
                    var stage = adminService.GetStageById(parameters.id);
                    if (stage == null)
                    {
                        adminService.CreateStage(parameters.competitionId, stageType.Id, new List<int>());
                    }
                    else
                    {
                        stage.StageType = stageType;
                        adminService.UpdateStage(stage);
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
