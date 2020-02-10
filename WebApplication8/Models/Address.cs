using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Address
    {
        public Address()
        {
            Branch = new HashSet<Branch>();
           // Client = new HashSet<Client>();
            Flat = new HashSet<Flat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int CityId { get; set; }

        public City City { get; set; }
        public virtual ICollection<Branch> Branch { get; set; }
        public virtual ICollection<Client> Client { get; set; }
        public  PersonDetail PersonDetails { get; set; }
        public virtual ICollection<Flat> Flat { get; set; }

    }
}
