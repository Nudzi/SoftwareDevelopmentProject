using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Agency.Models;
using Agency.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.ViewModel;

namespace Agency.Controllers
{
    public class AdminController : Controller
    {

        private readonly AgencyContext _context;

        public AdminController(AgencyContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int id)
        {
            //List<Microsoft.AspNetCore.Identity.IdentityRole> roles = _context.Roles.ToList();
            List<Employee> employee = _context.Employee.ToList();
            List<PersonDetail> lista = _context.PersonDetail.ToList();
            List<PersonDetail> list = new List<PersonDetail>();
            for (int i = 0; i < employee.Count; i++)
            {
                for (int j = 0; j < lista.Count; j++)
                {
                    if(employee[i].UserAccountId == lista[j].Id)
                    {
                        list.Add(new PersonDetail
                        {
                            Id = lista[j].Id,
                            AddressId = lista[j].AddressId, 
                            Date = lista[j].Date,
                            FirstName = lista[j].FirstName,
                            LastName = lista[j].LastName,
                            MojIdentityUserId = lista[j].MojIdentityUserId,
                            Verified = lista[j].Verified
                        });
                    }
                }
            }
            ViewData["personList"] = list;
            //ViewData["role"] = roles;
            //ViewData["employeeList"] = employee;

            return View("Index");
        }
        public IActionResult Create()
        {
            
            //ViewBag.ResultMessage = "Role created successfully!";
            return RedirectToAction("Index");
        }
        public List<City> GetCity(int id)
        {
            
             List<City > grad = _context.City.Where(u => u.CountryId == id).Select(g => new City
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
        static int idP;
        public IActionResult Update(int id)
        {
            //List<PersonDetail> list = _context.PersonDetail.Where(p => p.Id == id).ToList();
            //ViewData["personList"] = list;
            //return View("Update");



            if (id != 0)
            {           //ako je FakultetID!=0 ---> edit
                PersonDetail obj = _context.PersonDetail.Find(id);
                ViewData["PersonKey"] = obj;
            }
            else
            {
                //ako je FakultetID=0 ---> dodaj
                ViewData["PersonKey"] = new PersonDetail();
            }

            //za combo box
            //List<PersonDetail> podaci = _context.PersonDetail.Select(s => new PersonDetail
            //{
            //    Id = s.Id,
            //    FirstName = s.FirstName,
            //    LastName = s.LastName,
            //    Verified = s.Verified,
            //}).ToList();

            //ViewData["OsobaKey"] = podaci;
            idP = id;
            //person.Date = p.Date;
            
            return View("Update");
        }
        static string first;
        static string last;
        public ActionResult SaveToMap(int Id, string First, string Last)
        {   //snimi (dodaj novi i edit)

            if (idC != 0 && idA != 0 && idCi != 0)
            {
                AdresForm a = new AdresForm();

                a.NameAddress = _context.Address.Find(idA).Name;
                a.NameCity = _context.City.Find(idCi).Name;
                a.NameCountry = _context.Country.Find(idC).Name;
                a.Id = idA;
                a.IdCity = idCi;
                a.IdCounty = idC;
                ViewData["p"] = a;
            }

            PersonDetail f;
            if (Id == 0)
            {
                //dodaj
                f = new PersonDetail();
                //db.Add(f);
            }
            else
            {
                //edit
                f = _context.PersonDetail.Find(Id);
            }
            if (First != null || Last != null)
            {
                first = f.FirstName;
                last = f.LastName;
                f.FirstName = First;
                f.LastName = Last;
            }
            _context.SaveChanges();

            return Redirect("Map");
        }
        public ActionResult Save(int Id, string First, string Last)
        {   //snimi (dodaj novi i edit)

            if(idC != 0 && idA != 0 && idCi != 0)
            {
                AdresForm a = new AdresForm();

                a.NameAddress = _context.Address.Find(idA).Name;
                a.NameCity = _context.City.Find(idCi).Name;
                a.NameCountry = _context.Country.Find(idC).Name;
                a.Id = idA;
                a.IdCity = idCi;
                a.IdCounty = idC;
                ViewData["p"] = a;
            }

            PersonDetail f;
            if (Id == 0)
            {
                //dodaj
                f = new PersonDetail();
                //db.Add(f);
            }
            else
            {
                //edit
                f = _context.PersonDetail.Find(Id);
            }
            if (First != null || Last != null)
            {
                first = f.FirstName;
                last = f.LastName;
                f.FirstName = First;
                f.LastName = Last;
            }
            _context.SaveChanges();

            return Redirect("Index");
        }
        public ActionResult SaveAll(int Id, string country, string city, string address, string first)
        {   //snimi (dodaj novi i edit)

            PersonDetail person = _context.PersonDetail.Find(idP);
            person.AddressId = idA;
            //person.Address.CityId = idCi;
            //person.Address.City.CountryId = idC; 
            //person.Address.Name = _context.Address.Find(idA).Name;
            //person.Address.City.Name = _context.City.Find(idCi).Name;
            //person.Address.City.Country.Name = _context.Country.Find(idC).Name;
            ViewData["person"] = person;
            _context.SaveChanges();

            return Redirect("Index");
        }
        public ActionResult Message()
        {
            return View("Message");
        }
        public IActionResult Delete(int Id){
            PersonDetail obj = _context.PersonDetail.Find(Id);
            _context.Remove(obj);
            TempData["keyPoruka"] = obj.FirstName + " " + obj.LastName;
            _context.SaveChanges();

            return Redirect("Message");
        }
        public ActionResult MessageD()
        {
            return View();
        }
        public IActionResult All()
        {
            AdresForm a = new AdresForm();

            a.NameAddress = _context.Address.Find(idA).Name;
            a.NameCity = _context.City.Find(idCi).Name;
            a.NameCountry = _context.Country.Find(idC).Name;
            a.Id = idA;
            a.IdCity = idCi;
            a.IdCounty = idC;

            PersonForm person = new PersonForm();
            PersonDetail pd = _context.PersonDetail.Find(idP);
            person.FirstName = pd.FirstName;
            person.LastName = pd.LastName;
            person.Verified = pd.Verified;
            ViewData["person"] = person;
            ViewData["p"] = a;
            
            return View("All");
        }
        public IActionResult Dismiss()
        {
            PersonDetail person = _context.PersonDetail.Find(idP);
            person.FirstName = first;
            person.LastName = last;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}