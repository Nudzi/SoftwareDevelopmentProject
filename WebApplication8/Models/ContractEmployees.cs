using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class ContractEmployees
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int EmployerId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Employee Employer { get; set; }
    }
}
