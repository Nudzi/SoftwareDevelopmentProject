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
    public class ClientController : Controller
    {
        private readonly AgencyContext _context;

        private readonly UserManager<MojIdentityUser> _userManager;
        public ClientController(AgencyContext context, UserManager<MojIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        static int idP;
       

        //public ClientController(UserManager<MojIdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        public IActionResult Index()
        {

            //logiranje i indeks
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            
            //if (User.IsInRole("Client"))
            //     id = 10;

            PersonDetail person = new PersonDetail();
            Client client = new Client();
            List<PersonDetail> persons = _context.PersonDetail.ToList();
            List<Client> clients = _context.Client.ToList();
            if(clients[clients.Count-1].MojIdentityUserId == null)
            {
                clients[(clients.Count) - 1].MojIdentityUserId = userId;
            }
            for (int i = 0; i < clients.Count; i++)
            {
                if(clients[i].MojIdentityUserId == userId)
                {
                    client = _context.Client.Find(clients[i].Id);
                    for (int j = 0; j < persons.Count; j++)
                    {
                        if(persons[j].Id == clients[i].UserAccountid)
                        {
                            person = _context.PersonDetail.Find(persons[j].Id);
                            persons[j].MojIdentityUserId = clients[i].MojIdentityUserId;
                           // person.Address.CityId = persons[j].Address.CityId;
                        }
                    }
                }
            }
            
            AdresForm a = new AdresForm();

            a.Id = person.AddressId;
            a.NameAddress = _context.Address.Find(person.AddressId).Name;
            //a.IdCity = person.Address.CityId;
            //a.IdCounty = person.Address.City.CountryId;
          //  a.NameCity = _context.City.Find(person.Address.CityId).Name;
           // a.NameCountry = _context.Country.Find(person.Address.City.CountryId).Name;
            idA = person.AddressId;
           // idCi = person.Address.CityId;
          //  idC = person.Address.City.CountryId;
            idP = person.Id;
            ViewData["person"] = person;
            ViewData["a"] = a;
            ViewData["client"] = client;
            _context.SaveChanges();
            return View("Index");
        }
        public PersonDetail GetPerson(int id)
        {
            List<PersonDetail> lista = _context.PersonDetail.ToList();
            Client client = _context.Client.Find(id);
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Id == client.UserAccountid)
                {
                    return  _context.PersonDetail.Find(lista[i].Id);
                }
            }
            return null;
        }
        public IActionResult Update(int id)
        {
            if (id != 0)
            {
                Client client = _context.Client.Find(id);
                PersonDetail person = GetPerson(id);
                ViewData["person"] = person;
                ViewData["client"] = client;
            }
            else
            {
                
            }
            return View("Update");
        }
        static int idAll;
        public IActionResult Save(int id, string first, string last)
        {
            Client client = _context.Client.Find(id);
            PersonDetail person = GetPerson(id);
            idAll = id;
            person.FirstName = first;
            person.LastName = last;
            _context.SaveChanges();
            return Redirect("Index");
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
            ViewData["adresa"] = new List<Address>();
            ViewData["grad"] = new List<City>();
            List<Country> country = _context.Country.ToList();
            ViewData["countryList"] = country;
            return View("Map");
        }
        public IActionResult All()
        {
            List<PersonDetail> persons = _context.PersonDetail.ToList();
            for (int i = 0; i < persons.Count; i++)
            {
                if(persons[i].MojIdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                {
                    persons[i].AddressId = idA;

                }
            }
            //person.Address.CityId = idCi;
            //person.Address.City.CountryId = idC;

            //person.Address.Name = _context.Address.Find(idA).Name;
            //person.Address.City.Name = _context.City.Find(idCi).Name;
            //person.Address.City.Country.Name = _context.Country.Find(idC).Name;
            _context.SaveChanges();
            // MessageBox.Show();
            return Redirect("Index");
        }
    }
}