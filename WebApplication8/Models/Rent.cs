using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Rent
    {
        public Rent()
        {
            Contract = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int FlatId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Verified { get; set; }

        public virtual Client Client { get; set; }
        public virtual Flat Flat { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
    }
}
