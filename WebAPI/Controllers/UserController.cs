using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    using Models.RequestModels;
    using Models.ResponseModels;
    using BLL.Services;
    using BLL.DTO;

    public class UserController : ApiController
    {
        public IHttpActionResult Post([FromBody] UserRequestModel parameters)
        {
            UserResponseModel user;
            using (var service = new GuestService("CompetitionContext"))
            {
                var serviceResponse = service.GetUser(parameters.login, parameters.password);
                user = ObjectMapper.ObjectMapperDTOModel.UserToModel(serviceResponse.user, serviceResponse.isPasswordValid);
            }
            return Json(user);
            //return Json(Test.TestDataForUserParticipant());
        }
    }
}
