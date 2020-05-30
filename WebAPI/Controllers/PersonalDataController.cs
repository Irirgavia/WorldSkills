using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BLL.Services;
using BLL.DTO;
using WebAPI.Models.RequestModels;
using WebAPI.Models.ResponseModels;
using WebAPI.ObjectMapper;

namespace WebAPI.Controllers
{
    public class PersonalDataController : ApiController
    {
        public IHttpActionResult Get([FromBody] int userId)
        {
            PersonalDataResponseModel personalDataResponse;
            using (var adminService = new BLL.Services.AdministratorService("CompetitionContext"))
            {
                ParticipantDTO participantDTO = adminService.GetParticipantByUserId(userId);
                personalDataResponse = ObjectMapperDTOModel.ToPersonalDataResponseModel(participantDTO);
            }
            return Json(personalDataResponse);
        }

        public IHttpActionResult Update([FromBody] PersonalDataSaveRequestModel parameters)
        {
            using (var adminService = new BLL.Services.AdministratorService("CompetitionContext"))
            {
                UserDTO userDTO = adminService.GetUserById(parameters.userId);
                userDTO.Surname = parameters.surname;
                userDTO.Name = parameters.name;
                userDTO.Patronymic = parameters.patronymic;
                string[] splitDate = parameters.birthday.Split('.');
                int day = int.Parse(splitDate[0]);
                int month = int.Parse(splitDate[0]);
                int year = int.Parse(splitDate[0]);
                userDTO.Birthday = new DateTime(year, month, day);
                userDTO.Mail = parameters.mail;
                userDTO.Telephone = parameters.telephone;

                adminService.UpdateUser(userDTO);

                AddressDTO addressDTO = adminService.GetAddressById(parameters.addressId);
                addressDTO.Country = parameters.country;
                addressDTO.City = parameters.city;
                addressDTO.Street = parameters.street;
                addressDTO.House = parameters.house;

                adminService.UpdateAddress(addressDTO);
            }
            return Ok();
        }
    }
}
