using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    using BLL;
    using BLL.DTO;
    using BLL.Services;

    using WebGrease.Css.Extensions;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        /*
        public JsonResult GetActualTimetable(string skill)
        {
            var guestService = new GuestService();
            var timetable = guestService.GetActualCompetitions().Select(
                c => c.Stages.Select(
                    s => s.Tasks.Select(
                        t => new
                                 {
                                     Skill = c.Skill, 
                                     TypeStage = s.TypeStage, 
                                     Data = t.DateTime,
                                     Address = t.Address
                                 })));

            return Json(timetable, JsonRequestBehavior.AllowGet);
        }*/
    }
}
