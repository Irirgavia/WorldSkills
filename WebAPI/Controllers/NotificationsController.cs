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
            var systemService = ServiceProvider.GetSystemService();
            try
            {
                var notifications = systemService.GetNotificationByToAccountId(userId.id);
                ICollection<Models.ResponseModels.NotificationResponseModel> response = new List<Models.ResponseModels.NotificationResponseModel>();
                foreach (var notificationDTO in notifications)
                {
                    response.Add(ObjectMapperDTOModel.ToModel(notificationDTO));
                }
                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/notifications/amount")]
        public IHttpActionResult Amount([FromBody] UserIdRequestModel userId)
        {
            var systemService = ServiceProvider.GetSystemService();
            try
            {
                var notifications = systemService.GetNotificationByToAccountId(userId.id);
                var amountUnreadNotifications = notifications.Select(n => n.IsRead == false).Count();
                return Json(amountUnreadNotifications);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Read([FromUri] int notificationId, [FromUri] int userId)
        {
            var systemService = ServiceProvider.GetSystemService();
            try
            {
                var notification = systemService.GetNotificationById(notificationId);
                notification.IsRead = true;
                systemService.UpdateNotification(notification);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
