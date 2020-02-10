using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Agency.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        AgencyContext agencyContext;


        public HomeController(AgencyContext agencyContext)
        {
            this.agencyContext = agencyContext;
        }

        public IActionResult Index()
        {
           if (this.User.IsInRole("Client"))
                return View("Index_Client");
            if (this.User.IsInRole("Admin"))
                return View("Index_Admin");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
