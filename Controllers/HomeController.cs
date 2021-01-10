using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreState.Models;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreState.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession session;
        public HomeController(ISession session)
        {
            this.session = session;
        }

        public IActionResult Index()
        {
            var model = new YearViewModel
            {
                Year = session.GetInt32("Year")
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(YearViewModel inputModel)
        {
            if (inputModel.Year.HasValue)
            {
                session.SetInt32("Year", inputModel.Year.Value);
            }
            else
            {
                session.Remove("Year");
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
