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

            return Json(Test(skill, stage, year));
        }

        private IEnumerable<ResultsElement> Test(string skill, string stage, int year)
        {
            ICollection<ResultsElement> resultsElements = new List<ResultsElement>();
            var resultsElement1 = new ResultsElement()
            {
                Date = "2019, 03, 12",
                Participant = "participant1",
                Marks = 5
            };
            var resultsElement2 = new ResultsElement()
            {
                Date = "2019, 03, 14",
                Participant = "participant2",
                Marks = 7
            };
            resultsElements.Add(resultsElement1);
            resultsElements.Add(resultsElement2);
            return resultsElements;
        }
    }
}
