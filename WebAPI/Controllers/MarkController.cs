﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class MarkController : ApiController
    {
        public IHttpActionResult Save([FromBody] int answerId, [FromBody] int mark)
        {
            /*var guestService = new GuestService("CompetitionContext");
            var competitions = guestService.GetActualCompetitions();
            foreach(var competition in competitions)
            {
                scheduleElements.Add(ObjectMapperDTOModel.ToModel(competition));
            }*/
            return Json(/*scheduleElements*/ Test.TestDataForSchedule());
        }
    }
}
