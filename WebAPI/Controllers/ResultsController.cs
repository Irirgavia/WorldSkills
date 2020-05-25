namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Models;

    public class ResultsController : ApiController
    {
        //"http://localhost:49263/api/results?skill=skill&stage=stage&year=2020"
        //[Route(("skill={skill}&stage={stage}&year={year:range(2000, 3000)}"))]
        public IHttpActionResult Get([FromUri]string skill, [FromUri] string stage, [FromUri] int year)
        {
            if (year < 2000 || year > 3000)
                return BadRequest();
            ICollection<ResultsElement> resultsElements = new List<ResultsElement>();

            return Json(Test.TestDataForResults(skill, stage, year));
        }
    }
}
