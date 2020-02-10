using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.ViewModel
{
    public class AdresForm
    {
        public int? IdCity { get; set; }
        // [ForeignKey("City")]
        public string? NameCity { get; set; }
        public int  IdCounty { get; set; }
        public string? NameCountry { get; set; }
        public int? Id { get; set; }
        public string? NameAddress { get; set; }
    }
}
