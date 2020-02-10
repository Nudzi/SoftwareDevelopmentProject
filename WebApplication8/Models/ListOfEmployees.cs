using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class ListOfEmployees
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Employee Employer { get; set; }
    }
}
