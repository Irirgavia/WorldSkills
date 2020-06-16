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
                var competitions = competitionService.GetAllCompetitions();
                foreach (var competition in competitions)
                {
                    var skill = competition.Skill.Name;
                    if(!skills.Contains(skill))
                    {
                        skills.Add(skill);
                    }
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
