using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BLL.Services;
using BLL.DTO;
using WebAPI.Models.RequestModels;

namespace WebAPI.Controllers
{
    public class PersonalDataController : ApiController
    {
        public IHttpActionResult Get([FromBody] int userId)
        {
            return Json(Test.TestDataForUserParticipant());
        }

        public IHttpActionResult Update([FromBody] PersonalDataSaveRequestModel parameters)
        {
            using (var patricipantService = new BLL.Services.ParticipantService("CompetitionContext"))
            {

            }
            return Json(Test.TestDataForUserParticipant());
        }
    }
}
