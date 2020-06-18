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
    using ObjectMapper;
    using BLL.DTO.Account;

    public class TaskController : ApiController
    {
        [Route("api/task/save")]
        public IHttpActionResult Save([FromBody] TaskSaveRequestModel parameters)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var competitionService = ServiceProvider.GetCompetitionService();
            DateTime begin = ObjectMapperDTOModel.ParseToDateTime(parameters.taskDateOfBegin);
            DateTime end = ObjectMapperDTOModel.ParseToDateTime(parameters.taskDateOfEnd);
            TimeSpan duration = end - begin;
            try
            {
                if (parameters.id != -1)
                {
                    competitionService.CreateTask(parameters.stageId, begin, duration, parameters.description, null, new List<AddressDTO>(), new List<AnswerDTO>());
                }
                else
                {
                    var task = competitionService.GetTaskById(parameters.id);
                    if (task == null)
                    {
                        competitionService.CreateTask(parameters.stageId, begin, duration, parameters.description, null, new List<AddressDTO>(), new List<AnswerDTO>());
                    }
                    else
                    {
                        task.StageId = parameters.stageId;
                        task.DateTimeBegin = begin;
                        task.DurationTime = duration;
                        task.Description = parameters.description;
                    }
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
