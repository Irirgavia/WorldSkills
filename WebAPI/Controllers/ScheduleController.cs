namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models;

    public class ScheduleController : ApiController
    {
        public IHttpActionResult Get()
        {
            ICollection<ScheduleElement> scheduleElements = new List<ScheduleElement>();
            
            return Json(Test());
        }

        private IEnumerable<ScheduleElement> Test()
        {
            ICollection<ScheduleElement> scheduleElements = new List<ScheduleElement>();
            var scheduleElement1 = new ScheduleElement()
            {
                Skill = "skill1",
                Stage = "stage1",
                DateOfBegin = new DateTime(2019, 03, 12),
                DateOfEnd = new DateTime(2019, 09, 20),
                Address = "address1"
            };
            var scheduleElement2 = new ScheduleElement()
            {
                Skill = "skill2",
                Stage = "stage2",
                DateOfBegin = new DateTime(2019, 03, 14),
                DateOfEnd = new DateTime(2019, 09, 22),
                Address = "address2"
            };
            scheduleElements.Add(scheduleElement1);
            scheduleElements.Add(scheduleElement2);
            return scheduleElements;
        }
    }
}
