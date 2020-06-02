namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Services.Protocols;

    using BLL.DTO.Account;
    using WebAPI.Models.RequestModels;
    using WebAPI.Models.ResponseModels;
    using WebAPI.ObjectMapper;
    using WebAPI.ServiceProvider;

    public class PersonalDataController : ApiController
    {
        [Route("api/personaldata")]
        public IHttpActionResult Receive([FromBody] UserIdRequestModel userId)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            AccountDTO accountDTO = adminService.GetAccountById(userId.id);
            var personalDataResponse = ObjectMapperDTOModel.ToPersonalDataResponseModel(accountDTO);
            return Json(personalDataResponse);
        }

        [Route("api/personaldata/update")]
        public IHttpActionResult Update([FromBody] PersonalDataSaveRequestModel parameters)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            AccountDTO accountDTO = adminService.GetAccountById(parameters.userId);
            var personalDataDTO = accountDTO.PersonalData;
            var addressDTO = personalDataDTO.Address;

            addressDTO.Country = parameters.country;
            addressDTO.City = parameters.city;
            addressDTO.Street = parameters.street;
            addressDTO.House = parameters.house;

            adminService.UpdateAccountAddress(addressDTO);

            personalDataDTO.Surname = parameters.surname;
            personalDataDTO.Name = parameters.name;
            personalDataDTO.Patronymic = parameters.patronymic;
            personalDataDTO.Birthday = ObjectMapperDTOModel.ParseToDateTime(parameters.birthday);
            personalDataDTO.Mail = parameters.mail;
            personalDataDTO.Telephone = parameters.telephone;

            adminService.UpdatePersonalData(personalDataDTO);

            return Ok();
        }
    }
}
