using Agency.Models;
using Agency.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Agency.ViewModel;

namespace WebApplication8.Controllers
{
    public class FlatController : Controller
    {
        private readonly AgencyContext _context;
        private readonly IMapper _mapper;

        public FlatController(AgencyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Show(int id)
        {
            Flat flat = _context.Flat.Find(id);
            ViewData["flat"] = flat;
            AdresForm a = new AdresForm();
            a.NameAddress = _context.Address.Find(flat.AddressId).Name;
            a.NameCity = _context.City.Find(flat.Address.CityId).Name;
            a.NameCountry = _context.Country.Find(flat.Address.City.CountryId).Name;
            a.Id = flat.AddressId;
            a.IdCity = flat.Address.CityId;
            a.IdCounty = flat.Address.City.CountryId;
            ViewData["address"] = a;
            return View("Show");
        }
        
        public IActionResult Index()
        {
            List<Picture> picture = _context.Picture.ToList();
            List<Flat> flat = _context.Flat.ToList();
            ViewData["flat"] = flat;
            ViewData["picture"] = picture;
            return View("IndexShow");
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult Index(int id)
        //{
        //   // var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
        //    FlatForm flatForm;
        //    Flat flat = null;

        //    if (id != 0)
        //        flat = _context.Flat
        //            .Where(x => x.Id == id)
        //            .Include(y => y.Address)
        //            .ThenInclude(z => z.City)
        //            .Include(r => r.Room)
        //            .ThenInclude(p => p.Pictures)
        //            .FirstOrDefault();

        //    if (flat != null)
        //    {
        //        flatForm = _mapper.Map<FlatForm>(flat);
        //    }
        //    else
        //    {

        //        flatForm = new FlatForm();

        //        flatForm.Address.Countries = _context.Country
        //                .Select(x => new SelectListItem
        //                { Value = x.Id.ToString(), Text = x.Name })
        //                .ToList();

        //        flatForm.Address.Countries
        //            .Insert(0, new SelectListItem("Choose Country", "0", true, true));

        //        flatForm.Address.Cities = new List<SelectListItem>();
        //        flatForm.Address.Cities
        //            .Insert(0, new SelectListItem("Choose City", "0", true, true));
        //    }

        //    return View(flatForm);
        //}

        //[HttpPost]
        //[Authorize]
        //public IActionResult Index(int id, FlatForm flatForm)
        //{
        //    Flat flat = _context.Flat
        //            .Where(x => x.Id == id)
        //            .Include(y => y.Address)
        //            .ThenInclude(z => z.City)
        //            .Include(r => r.Room)
        //            .ThenInclude(p => p.Pictures)
        //            .FirstOrDefault();

        //    if (flat == null)
        //    {
        //        flat = _mapper.Map<Flat>(flatForm);
        //        _context.Flat.Add(flat);
        //    }
        //    else
        //    {
        //        _mapper.Map(flatForm, flat);
        //        _context.Flat.Update(flat);
        //    }

        //    _context.SaveChanges();
        //    id = flat.Id;

        //    return RedirectToAction(nameof(Index), new { id = id });
        //}
        

    }
}