using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Post([FromBody] (string login, string password) parameters)
        {

            return Json(Test.TestDataForUserParticipant());
        }
    }
}
