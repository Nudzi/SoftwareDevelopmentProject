using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Agency.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int Quadrature { get; set; }
        public int FlatId { get; set; }
        public virtual List<PictureViewModel> Pictures { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
}
