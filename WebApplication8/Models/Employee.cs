using System;
using System.Collections.Generic;
using WebApplication8.Areas.Identity.Data;

namespace Agency.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ContractEmployees = new HashSet<ContractEmployees>();
            ListOfEmployees = new HashSet<ListOfEmployees>();
        }

        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<ContractEmployees> ContractEmployees { get; set; }
        public virtual ICollection<ListOfEmployees> ListOfEmployees { get; set; }

        public virtual MojIdentityUser MojIdentityUser { get; set; }
        public virtual string MojIdentityUserId { get; set; }


    }
}
