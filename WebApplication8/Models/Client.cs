using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication8.Areas.Identity.Data;

namespace Agency.Models
{
    public partial class Client
    {
        public Client()
        {
            Rent = new HashSet<Rent>();
            Review = new HashSet<Review>();
            Whishlist = new HashSet<Whishlist>();
        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public int TransactionId { get; set; }
        public int UserAccountid { get; set; }

        public virtual Address Address { get; set; }
        public virtual PaymentMethod Transaction { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Whishlist> Whishlist { get; set; }


        public virtual MojIdentityUser MojIdentityUser { get; set; }
        public virtual string MojIdentityUserId { get; set; }

    }
}
