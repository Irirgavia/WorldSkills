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
            using (var patricipantService = new BLL.Services.ParticipantService("CompetitionContext"))
            {

            }
            return Json(Test.TestDataForUserParticipant());
        }
    }
}
