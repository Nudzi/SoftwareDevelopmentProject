using Agency.Models;
using Agency.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agency.Helpers;
using System.Collections.Generic;

namespace Agency.Controllers
{
    public class RoomController : Controller
    {
        private readonly AgencyContext _context;
        private readonly IMapper _mapper;


        public RoomController(AgencyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            Room room = _context.Room.Find(id);
            if(room == null)
            {
                return "Error: Room could not be found!";
            }
            _context.Room.Remove(room);
            _context.SaveChanges();

            return "Room successfully removed!";
        }

        [HttpGet]
        public IActionResult Preview(int flatId)
        {
            List<RoomViewModel> roomViewModels = _mapper.Map<List<RoomViewModel>>(
                _context.Room
                    .Where(x => x.FaltId == flatId)
                    .Include(y => y.Pictures)
                    .ToList()
            );

            return View("Preview", roomViewModels);
        }


        [HttpGet]
        public IActionResult Index(int id, int flatId)
        {
            RoomViewModel roomViewModel = _mapper.Map<RoomViewModel>(
            _context.Room
                .Where(x => x.Id == id)
                .Include(y => y.Pictures)
                .FirstOrDefault());

            if(roomViewModel == null)
            {
                roomViewModel = new RoomViewModel();
                roomViewModel.FlatId = flatId;
            }
            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult Index(RoomViewModel roomViewModel)
            {
            if (roomViewModel == null)
                return BadRequest("RoomViewModel could not be empty!");
            Room room = _context.Room
                    .Where(x => x.Id == roomViewModel.Id)
                    .Include(p => p.Pictures)
                    .FirstOrDefault();

            if (room == null)
            {
                if (roomViewModel.FlatId == 0)
                    return BadRequest("Error flatId could not be found.");
                room = _mapper.Map<Room>(roomViewModel);
                room.FaltId = roomViewModel.FlatId;
                _context.Room.Add(room);
            }
            else
            {
                _mapper.Map(roomViewModel, room);
                _context.Room.Update(room);
            }

            _context.SaveChanges();

            RoomViewModel roomVM =_mapper.Map<RoomViewModel>(room);
            return View(roomVM);
        }
    }
}