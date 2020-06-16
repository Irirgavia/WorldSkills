namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models.ResponseModels;
    using ObjectMapper;
    using ServiceProvider;

    public class ScheduleController : ApiController
    {
        public IHttpActionResult Get()
        {
            ICollection<ScheduleElementResponseModel> scheduleElements = new List<ScheduleElementResponseModel>();
            var competitionService = ServiceProvider.GetCompetitionService();
            try
            {
                var competitions = competitionService.GetActualCompetitions();
                foreach (var competition in competitions)
                {
                    scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
                }
                return Json(scheduleElements);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
