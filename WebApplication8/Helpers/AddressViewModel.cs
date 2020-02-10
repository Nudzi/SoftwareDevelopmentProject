using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Agency.Helper
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            Cities = new List<SelectListItem>();
            Countries = new List<SelectListItem>();
        }

        // Columns
        public string Name { get; set; }
        public int Number { get; set; }
        public int CityId { get; set; }

        public int CountryId { get; set; }

        // For selection
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Countries { get; set; }
    }
}
