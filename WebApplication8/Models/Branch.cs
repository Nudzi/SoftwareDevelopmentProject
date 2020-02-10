using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Branch
    {
        public Branch()
        {
            ListOfEmployees = new HashSet<ListOfEmployees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<ListOfEmployees> ListOfEmployees { get; set; }
    }
}
