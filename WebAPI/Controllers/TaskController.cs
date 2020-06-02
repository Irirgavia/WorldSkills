using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.RequestModels;

namespace WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        [Route("api/task/save")]
        public IHttpActionResult Save([FromBody] TaskSaveRequestModel parameters)
        {
            return BadRequest();
        }
    }
}
