using System.Collections.Generic;
using System.Linq;
using Agency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication8.Controllers
{
    public class AddressController : Controller
    {
        private readonly AgencyContext _context;

        public AddressController(AgencyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetCitiesByCountryId(int id)
        {
            List<SelectListItem> cities = _context.City
                .Where(x => x.CountryId == id)
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .OrderBy(x => x.Value)
                .ToList();
            cities.Insert(0, new SelectListItem("Choose City", "0", true, true));

            return Json(cities);
        }
    }
}