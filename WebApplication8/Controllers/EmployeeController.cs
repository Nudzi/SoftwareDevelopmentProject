using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Agency.Helper;
using Agency.Models;
using Agency.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Agency.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AgencyContext _context;

        public EmployeeController(AgencyContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpPost]
        [Authorize]
        public IActionResult PreviewRents(int rentId, bool response, string description)
        {
            Rent rent = _context.Rent
                .Where(x => x.Verified == false && rentId == x.Id)
                .Include(z => z.Flat)
                .Include(y => y.Client)
                .FirstOrDefault();

            if(rent == null)
            {
                return Ok("That type of rent dose not exist!");
            }
            
            if(response)
            {
                Contract contract = new Contract();
                contract.RentId = rentId;
                contract.Date = DateTime.Now;
                contract.Desciption = description;
                contract.Price = rent.Flat.Amount * (rent.To - rent.From).Days;
                _context.Contract.Add(contract);
            }
            else
            {
                rent.Verified = false;
                _context.Rent.Add(rent);
            }
            _context.SaveChanges();
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult PreviewRents()
        {
            List<Rent> rents = _context.Rent
                .Where(x => x.Verified == false)
                .Include(z => z.Flat)
                .Include(y => y.Client)
                .ToList();

            List<RentViewModel> rentDetails = _mapper.Map<List<RentViewModel>>(rents);

            return View(rentDetails);
        }

        [HttpPost]
        [Authorize]
        public IActionResult PreviewRents(int id, bool verified)
        {
            Rent rent = _context.Rent.Find(id);

            rent.Verified = verified;

            _context.Rent.Update(rent);
            _context.SaveChanges();

            return View();
        }




        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var employerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PersonDetail personDetails = _context.PersonDetail
                .Where(x => x.MojIdentityUserId == employerId)
                .Include(y => y.Address)
                .ThenInclude(c => c.City)
                .FirstOrDefault();

            PersonDetailViewModel personDetailViewModel = _mapper.Map<PersonDetailViewModel>(personDetails);

            return View(personDetailViewModel);
        }



        [HttpPost]
        [Authorize]
        public IActionResult Index(PersonDetailViewModel personDetailsViewModel)
        {

            var employerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            PersonDetail personDetails = _context.PersonDetail.Where(x => x.MojIdentityUserId == employerId).FirstOrDefault();

            _mapper.Map(personDetailsViewModel, personDetails);




            return null;
        }
    }
}