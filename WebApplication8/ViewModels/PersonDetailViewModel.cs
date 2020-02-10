using Agency.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.ViewModels
{
    public class PersonDetailViewModel
    {
        public PersonDetailViewModel()
        {
            Address = new AddressViewModel();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool Verified { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
