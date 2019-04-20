using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Components.Demo.Components
{
    public class TechnologiesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var technologies = new List<string>
            {
                "ASP.NET",
                "PHP",
                "Rubby",
                "Reactjs"
            };

            return View(technologies);
        }
    }
}
