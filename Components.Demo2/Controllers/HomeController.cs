using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Components.Demo2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetTechnologies(int NoItems)
        {
            var technologies = new List<string>
            {
                "ASP.NET",
                "PHP",
                "Rubby",
                "Reactjs"
            };

            return PartialView(technologies.Take(NoItems).ToList());
        }


    }
}