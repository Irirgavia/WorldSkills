using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models.RequestModels;

namespace WebAPI.Controllers
{
    using BLL.DTO.Competition;
    using ServiceProvider;
    using System.Data.Entity.Core.Objects;
    using WebAPI.ObjectMapper;

    public class CompetitionController : ApiController
    {
        [Route("api/competition/admin")]
        public IHttpActionResult ReceiveByAdminId([FromBody] UserIdRequestModel adminId)
        {
            var service = ServiceProvider.GetGuestService();
            var competitions = service.GetAllCompetitions();
            ICollection<Models.ResponseModels.ForAdmin.CompetitionResponseModel> response = new List<Models.ResponseModels.ForAdmin.CompetitionResponseModel>();
            foreach(var competition in competitions)
            {
                response.Add(ObjectMapperDTOModelForAdmin.ToCompetitionForAdminResponseModel(competition));
            }
            return Json(response);
        }

        [Route("api/competition/participant")]
        public IHttpActionResult ReceiveByParticipant([FromBody] UserIdRequestModel participantId)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            var stages = adminService.GetStagesByAccountId(participantId.id);
            ICollection<Models.ResponseModels.ForParticipant.CompetitionForTaskResponseModel> response = new List<Models.ResponseModels.ForParticipant.CompetitionForTaskResponseModel>();
            foreach (var stage in stages)
            {
                response.Add(ObjectMapperDTOModelForParticipant.ToCompetitionForParticipantResponseModel(stage));
            }
            return Json(response);
        }

        [Route("api/competition/save")]
        public IHttpActionResult Save([FromBody] CompetitionSaveRequestModel parameters)
        {
            var adminService = ServiceProvider.GetAdministratorService();
            if (parameters.competitionId == -1)
                adminService.CreateCompetition(
                    ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfBegin),
                    ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfEnd),
                    parameters.skill);
            else
            {
                var competitionDTO=adminService.GetCompetitionById(parameters.competitionId);
                competitionDTO.DateTimeBegin = ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfBegin);
                competitionDTO.DateTimeEnd = ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfEnd);
                if (competitionDTO.Skill.Name != parameters.skill)
                {
                    var skillDTO = adminService.GetSkillByName(parameters.skill);
                    if (skillDTO == null)
                    {
                        adminService.CreateSkill(parameters.skill);
                    }
                    competitionDTO.Skill = skillDTO;
                }
                adminService.UpdateCompetition(competitionDTO);
            }
            return Ok();
        }
    }
}
