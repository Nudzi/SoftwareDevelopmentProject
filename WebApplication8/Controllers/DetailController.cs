using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Agency.Models;
using Agency.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Areas.Identity.Data;
using WebApplication8.ViewModel;
namespace Agency.Controllers
{
    public class DetailController : Controller
    {
        private readonly AgencyContext _context;

        private readonly UserManager<MojIdentityUser> _userManager;
        public DetailController(AgencyContext context, UserManager<MojIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        static int idP;
        string IdUser;

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            IdUser = userId;
            return View("Index");
        }



        public List<City> GetCity(int id)
        {

            List<City> grad = _context.City.Where(u => u.CountryId == id).Select(g => new City
            {
                Id = g.Id,
                Name = g.Name

            }
           ).ToList();
            ViewData["grad"] = grad;

            return grad;
        }
        public List<Address> GetAdres(int id)
        {

            List<Address> adresa = _context.Address.Where(u => u.CityId == id).Select(g => new Address
            {
                Id = g.Id,
                Name = g.Name
            }
           ).ToList();
            ViewData["adresa"] = adresa;

            return adresa;
        }
        static int idA;
        static int idC;
        static int idCi;

        public object MessageBox { get; private set; }

        public IActionResult Adresa(int id)
        {

            List<Country> country = _context.Country.ToList();
            ViewData["countryList"] = country;
            ViewData["grad"] = new List<City>();

            if (id != 0)
            {
                ViewData["adresa"] = (GetAdres(id));
            }
            else
            {
                ViewData["adresa"] = new List<Address>();
            }

            idCi = id;
            return View("Map");
        }
        public IActionResult Map()
        {
            List<Country> country = _context.Country.ToList();
            ViewData["countryList"] = country;
            ViewData["adresa"] = new List<Address>();
            ViewData["grad"] = new List<City>();

            return View("Map");
        }

        public IActionResult Grad(int id)
        {
            ViewData["adresa"] = new List<Address>();
            List<Country> country = _context.Country.ToList();
            ViewData["countryList"] = country;

            if (id != 0)
            {
                ViewData["grad"] = (GetCity(id));
            }
            else
            {
                ViewData["grad"] = new List<City>();
            }
            idC = id;
            return View("Map");
        }
        public IActionResult Value(int id)
        {
            idA = id;
            //PersonDetail p = _context.PersonDetail.Find(idP);
            // p.AddressId = id;
            _context.SaveChanges();
            ViewData["adresa"] = new List<Address>();
            ViewData["grad"] = new List<City>();
            List<Country> country = _context.Country.ToList();
            ViewData["countryList"] = country;
            return View("Map");
        }
        public PersonDetail GetPerson()
        {
            List<PersonDetail> lista = _context.PersonDetail.ToList();
            // Client client = _context.Client.Find(id);
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].MojIdentityUserId == IdUser)
                {
                    return _context.PersonDetail.Find(lista[i].Id);
                }
            }

            return null;
        }
        public IActionResult All()
        {
            PersonDetail person = GetPerson();
            person.AddressId = idA;
            Client client = new Client
            {
                AddressId = person.AddressId,
                TransactionId = 2,
                UserAccountid = person.Id,
                MojIdentityUserId = person.MojIdentityUserId
            };


            //person.Address.CityId = idCi;
            //person.Address.City.CountryId = idC;

            //person.Address.Name = _context.Address.Find(idA).Name;
            //person.Address.City.Name = _context.City.Find(idCi).Name;
            //person.Address.City.Country.Name = _context.Country.Find(idC).Name;
            _context.Client.Add(client);
            _context.SaveChanges();
            // MessageBox.Show();
            return Redirect("/Home");
        }

        public IActionResult Save(string first, string last, DateTime d)
        {
            PersonDetail person = new PersonDetail
            {
                FirstName = first,
                LastName = last,
                Date = d,
                MojIdentityUserId = IdUser,
                Verified = false,
                AddressId = 1
            };
            //  person.AddressId = 0;
            //idP = person.Id;
            _context.PersonDetail.Add(person);
            _context.SaveChanges();
            return Redirect("Map");
        }
    }
}