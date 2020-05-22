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
            /*var guestService = new GuestService("CompetitionContext");
            var competitions = guestService.GetActualCompetitions();
            foreach(var competition in competitions)
            {
                scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
            }*/
            return Json(/*scheduleElements*/ Test.TestDataForSchedule());
        }

        /*private IEnumerable<ScheduleElement> Test()
        {
            ICollection<ScheduleElement> scheduleElements = new List<ScheduleElement>();
            var scheduleElement1 = new ScheduleElement()
            {
                Skill = "skill1",
                Stages = "stage1",
                DateOfBegin = "2019, 03, 12",
                DateOfEnd = "2019, 09, 20",
                Address = "address1"
            };
            var scheduleElement2 = new ScheduleElement()
            {
                Skill = "skill2",
                Stages = "stage2",
                DateOfBegin = "2019, 03, 14",
                DateOfEnd = "2019, 09, 22",
                Address = "address2"
            };
            scheduleElements.Add(scheduleElement1);
            scheduleElements.Add(scheduleElement2);
            return scheduleElements;
        }*/
    }
}
