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
    using BLL.DTO.Account;

    public class UserController : ApiController
    {
        private static string loginExistsMessage = "LoginExists";
        private static string wrongPasswordMessage = "WrongPassword";
        private static string successMessage = "Success";

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

        public IHttpActionResult Save([FromBody] AccountDataSaveRequestModel accountData)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            var guestService = ServiceProvider.GetGuestService();
            var serviceResponse = guestService.GetAccount(accountData.oldLogin, accountData.oldPassword);
            var credentials = serviceResponse.account.Credentials;
            if (credentials.Login != accountData.newLogin)
            {
                var existedAccount = adminService.GetAccountByLogin(accountData.newLogin);
                if (existedAccount != null)
                {
                    return Json(loginExistsMessage);
                }
                else credentials.Login = accountData.newLogin;
            }
            if (!serviceResponse.isPasswordValid)
                return Json(wrongPasswordMessage);
            credentials.Password = accountData.newPassword;
            return Json(successMessage);
        }
    }
}
