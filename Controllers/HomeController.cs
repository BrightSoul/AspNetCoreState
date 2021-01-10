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
        public IActionResult Index([FromServices] IRequestCookieCollection cookies)
        {
            var model = new YearViewModel
            {
                Year = cookies.TryGetValue("Year", out string year) ? Convert.ToInt32(year) : null
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(YearViewModel inputModel, [FromServices] IResponseCookies cookies)
        {
            if (inputModel.Year.HasValue)
            {
                cookies.Append("Year", inputModel.Year.ToString(), new CookieOptions { HttpOnly = true, IsEssential = true, MaxAge = TimeSpan.FromDays(30) });
            }
            else
            {
                cookies.Delete("Year");
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
