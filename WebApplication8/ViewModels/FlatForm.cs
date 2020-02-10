using Agency.Helper;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agency.ViewModels
{
    public class FlatForm
    {
        public FlatForm()
        {
            Address = new AddressViewModel();
        }


        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public float Amount { get; set; }
        public bool NewFlat { get; set; }

        public AddressViewModel Address { get; set; }
        public ICollection<RoomViewModel> Room { get; set; }

        public List<IFormFile> Files { get; set; }

    }
}
