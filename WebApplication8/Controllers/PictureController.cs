using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agency.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agency.Controllers
{
    public class PictureController : Controller
    {
        private readonly AgencyContext _context;
        private readonly IMapper _mapper;


        public PictureController(AgencyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            Picture picture = _context.Picture.Find(id);
            if (picture == null)
            {
                return "Error: Picture could not be found!";
            }
            _context.Picture.Remove(picture);
            _context.SaveChanges();

            return "Picture successfully removed!";
        }

}
}