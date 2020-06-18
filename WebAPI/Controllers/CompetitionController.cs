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
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var service = ServiceProvider.GetCompetitionService();
            try
            {
                var competitions = service.GetAllCompetitions();
                ICollection<Models.ResponseModels.ForAdmin.CompetitionResponseModel> response =
                    new List<Models.ResponseModels.ForAdmin.CompetitionResponseModel>();
                foreach (var competition in competitions)
                {
                    response.Add(ObjectMapperDTOModelForAdmin.ToCompetitionForAdminResponseModel(competition));
                }

                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/competition/participant")]
        public IHttpActionResult ReceiveByParticipant([FromBody] UserIdRequestModel participantId)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var competitionService = ServiceProvider.GetCompetitionService();
            try
            {
                var stages = competitionService.GetStagesByAccountId(participantId.id);
                ICollection<Models.ResponseModels.ForParticipant.CompetitionForTaskResponseModel> response =
                    new List<Models.ResponseModels.ForParticipant.CompetitionForTaskResponseModel>();
                foreach (var stage in stages)
                {
                    response.Add(ObjectMapperDTOModelForParticipant.ToCompetitionForParticipantResponseModel(stage));
                }

                return Json(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/competition/save")]
        public IHttpActionResult Save([FromBody] CompetitionSaveRequestModel parameters)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            try
            {
                var competitionService = ServiceProvider.GetCompetitionService();
                if (parameters.competitionId == -1)
                    competitionService.CreateCompetition(
                        ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfBegin),
                        ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfEnd),
                        parameters.skill);
                else
                {
                    var competitionDTO = competitionService.GetCompetitionById(parameters.competitionId);
                    competitionDTO.DateTimeBegin = ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfBegin);
                    competitionDTO.DateTimeEnd = ObjectMapperDTOModel.ParseToDateTime(parameters.dateOfEnd);
                    if (competitionDTO.Skill.Name != parameters.skill)
                    {
                        var skillDTO = competitionService.GetSkillByName(parameters.skill);
                        if (skillDTO == null)
                        {
                            competitionService.CreateSkill(parameters.skill);
                        }

                        competitionDTO.Skill = skillDTO;
                    }

                    competitionService.UpdateCompetition(competitionDTO);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
