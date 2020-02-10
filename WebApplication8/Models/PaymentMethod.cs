using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Client = new HashSet<Client>();
        }

        public int Id { get; set; }
        public int? CardNumber { get; set; }
        public int? Other { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
