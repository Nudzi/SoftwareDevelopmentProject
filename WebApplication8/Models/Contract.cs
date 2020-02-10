using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Contract
    {
        public Contract()
        {
            ContractEmployees = new HashSet<ContractEmployees>();
        }

        public int Id { get; set; }
        public int BranchId { get; set; }
        public DateTime? Date { get; set; }
        public string Desciption { get; set; }
        public int EmployerId { get; set; }
        public int RentId { get; set; }
        public double Price { get; set; }

        public virtual Rent Rent { get; set; }
        public virtual ICollection<ContractEmployees> ContractEmployees { get; set; }
    }
}
