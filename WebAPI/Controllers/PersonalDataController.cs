using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BLL.Services;
using BLL.DTO;

namespace WebAPI.Controllers
{
    public class PersonalDataController : ApiController
    {
        public IHttpActionResult Get([FromBody] int userId)
        {
            return Json(Test.TestDataForUserParticipant());
        }

        public IHttpActionResult Update([FromBody] int userId,
            [FromBody] string surname,
            [FromBody] string name,
            [FromBody] string patronymic,
            [FromBody] string birthday,
            [FromBody] string mail,
            [FromBody] string telephone,
            [FromBody] int addressId,
            [FromBody] string country,
            [FromBody] string city,
            [FromBody] string street,
            [FromBody] string house)
        {
            using (var patricipantService = new BLL.Services.ParticipantService("CompetitionContext"))
            {

            }
            return Json(Test.TestDataForUserParticipant());
        }
    }
}
