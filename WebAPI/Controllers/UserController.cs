namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models.RequestModels;
    using Models.ResponseModels;
    using ServiceProvider;
    using BLL.DTO;

    public class UserController : ApiController
    {
        public IHttpActionResult Post([FromBody] UserRequestModel parameters)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            var stageType = adminService.GetStageTypeById(1);

            var guestService = ServiceProvider.GetGuestService();
            var serviceResponse = guestService.GetAccount(parameters.login, parameters.password);
            int unreadNotificationAmount = 0;
            var user = ObjectMapper.ObjectMapperDTOModel.AccountToModel(serviceResponse.account, serviceResponse.isPasswordValid, unreadNotificationAmount);

            return Json(user);
            //return Json(Test.TestDataForUserParticipant());
        }
    }
}
