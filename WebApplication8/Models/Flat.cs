using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Flat
    {
        public Flat()
        {
            Rent = new HashSet<Rent>();
            Review = new HashSet<Review>();
            Room = new HashSet<Room>();
            Whishlist = new HashSet<Whishlist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public int Floor { get; set; }
        public int? AgencyId { get; set; }
        public int AddressId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Room> Room { get; set; }
        public virtual ICollection<Whishlist> Whishlist { get; set; }
    
        
    }
}
