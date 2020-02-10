using System;
using WebApplication8.Areas.Identity.Data;

namespace Agency.Models
{
    public partial class PersonDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Date { get; set; }
        public bool Verified { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public virtual MojIdentityUser MojIdentityUser { get; set; }
        public virtual string MojIdentityUserId { get; set; }
    }
}
