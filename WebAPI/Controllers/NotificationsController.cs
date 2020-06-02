using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    using ServiceProvider;
    using Models.RequestModels;
    using ObjectMapper;

    public class NotificationsController : ApiController
    {
        [Route("api/notifications")]
        public IHttpActionResult Receive([FromBody] UserIdRequestModel userId)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            
            return Json("notificmess");
        }

        [Route("api/notifications/amount")]
        public IHttpActionResult Amount([FromBody] UserIdRequestModel userId)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            
            return Json(30);
        }

        public IHttpActionResult Read([FromUri] int notificationId, [FromUri] int userId)
        {
            var adminService = ServiceProvider.GetAdministratorService();

            return Ok();
        }
    }
}
