namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models;
    using ObjectMapper;
    using BLL.Services;

    public class ScheduleController : ApiController
    {
        public IHttpActionResult Get()
        {
            ICollection<ScheduleElement> scheduleElements = new List<ScheduleElement>();
            var guestService = new GuestService("CompetitionContext");
            var competitions = guestService.GetActualCompetitions();
            foreach(var competition in competitions)
            {
                scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
            }
            return Json(scheduleElements /*Test.TestDataForSchedule()*/);
        }
    }
}
