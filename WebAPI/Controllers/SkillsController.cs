using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    using ServiceProvider;

    public class SkillsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var competitionService = ServiceProvider.GetCompetitionService();
            ICollection<string> skills = new List<string>();
            try
            {
                var skillsDTO = competitionService.GetAllSkills();
                foreach (var skill in skillsDTO)
                {
                    skills.Add(skill.Name);
                }
                return Json(skills);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
