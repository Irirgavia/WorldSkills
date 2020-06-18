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
    using WebAPI.Models.ResponseModels.ForAdmin;
    using WebAPI.ObjectMapper;
    using WebAPI.ServiceProvider;

    public class PersonalDataController : ApiController
    {
        [Route("api/personaldata")]
        public IHttpActionResult Receive([FromBody] UserIdRequestModel userId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            try
            {
                var accountService = ServiceProvider.GetAccountService();
                AccountDTO accountDTO = accountService.GetAccountById(userId.id);
                var personalDataResponse = ObjectMapperDTOModel.ToPersonalDataResponseModel(accountDTO);
                return Json(personalDataResponse);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/personaldata/update")]
        public IHttpActionResult Update([FromBody] PersonalDataSaveRequestModel parameters)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            try
            {
                var accountService = ServiceProvider.GetAccountService();
                AccountDTO accountDTO = accountService.GetAccountById(parameters.userId);
                var personalDataDTO = accountDTO.PersonalData;

                personalDataDTO.Address.Country = parameters.country;
                personalDataDTO.Address.City = parameters.city;
                personalDataDTO.Address.Street = parameters.street;
                personalDataDTO.Address.House = parameters.house;

                personalDataDTO.Surname = parameters.surname;
                personalDataDTO.Name = parameters.name;
                personalDataDTO.Patronymic = parameters.patronymic;
                personalDataDTO.Birthday = ObjectMapperDTOModel.ParseToDateTime(parameters.birthday);
                personalDataDTO.Mail = parameters.mail;
                personalDataDTO.Telephone = parameters.telephone;

                accountService.UpdatePersonalData(personalDataDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/personaldata/updatebyadmin")]
        public IHttpActionResult UpdateByAdmin([FromBody] PersonalDataSaveByAdminRequestModel parameters)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            try
            {
                var accountService = ServiceProvider.GetAccountService();
                if (parameters.Id == -1)
                {
                    return BadRequest();
                }
                else
                {
                    AccountDTO accountDTO = accountService.GetAccountById(parameters.Id);
                    var personalDataDTO = accountDTO.PersonalData;

                    personalDataDTO.Address.Country = parameters.Country;
                    personalDataDTO.Address.City = parameters.City;
                    personalDataDTO.Address.Street = parameters.Street;
                    personalDataDTO.Address.House = parameters.House;
                    personalDataDTO.Address.Apartments = parameters.Apartment;

                    personalDataDTO.Surname = parameters.Surname;
                    personalDataDTO.Name = parameters.Name;
                    personalDataDTO.Patronymic = parameters.Patronymic;
                    personalDataDTO.Birthday = ObjectMapperDTOModel.ParseToDateTime(parameters.Birthday);
                    personalDataDTO.Mail = parameters.Mail;
                    personalDataDTO.Telephone = parameters.Telephone;

                    accountDTO.Credentials.Role = accountService.GetRoleByName(parameters.Role);

                    accountService.UpdatePersonalData(personalDataDTO);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/personaldata/all")]
        public IHttpActionResult ReceiveAllUsers([FromBody] UserIdRequestModel userId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            try
            {
                var accountService = ServiceProvider.GetAccountService();
                var accountsDTO = accountService.GetAllAccounts();
                ICollection<PersonalDataByAdminResponseModel> response = new List<PersonalDataByAdminResponseModel>();
                foreach (var account in accountsDTO)
                {
                    response.Add(ObjectMapperDTOModelForAdmin.ToPersonalDataByAdminResponseModel(account));
                }
                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
