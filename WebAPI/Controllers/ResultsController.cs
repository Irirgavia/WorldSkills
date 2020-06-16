namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models.ResponseModels;
    using Models.RequestModels;
    using ServiceProvider;
    using WebAPI.ObjectMapper;

    public class ResultsController : ApiController
    {
        //"http://localhost:49263/api/results?skill=skill&stage=stage&year=2020"
        //[Route(("skill={skill}&stage={stage}&year={year:range(2000, 3000)}"))]
        public IHttpActionResult Get([FromUri]string skill = "All", [FromUri] string stage = "All", [FromUri] int? year = null, [FromUri] bool isCSV = false)
        {
            if (skill == "All" && stage == "All" && year == null)
                return BadRequest();
            ICollection<ResultsElementResponseModel> resultsElements = new List<ResultsElementResponseModel>();
            var guestService = ServiceProvider.GetGuestService();
            var adminService = ServiceProvider.GetAdministratorService();
            if (skill == "All")
                skill = null;
            try
            {
                var competitions = guestService.GetCompetitionsBySkillAndYear(skill, year);
                foreach (var competition in competitions)
                {
                    resultsElements.Add(ObjectMapperDTOModel.ToResultsElementResponseModel(competition, stage, adminService));
                }
                return Json(resultsElements);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/results/participant")]
        public IHttpActionResult GetResultsByParticipant([FromBody] UserIdRequestModel userId)
        {
            List<Models.ResponseModels.ForParticipant.ResultForParticipantResponseModel> resultsElements = new List<Models.ResponseModels.ForParticipant.ResultForParticipantResponseModel>();
            var adminService = ServiceProvider.GetAdministratorService();
            try
            {
                var stages = adminService.GetStagesByAccountId(userId.id);
                foreach (var stage in stages)
                {
                    resultsElements.AddRange(ObjectMapperDTOModelForParticipant.ToResultForParticipantResponseModel(stage, userId.id, adminService));
                }
                return Json(resultsElements);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
