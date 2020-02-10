using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Category
    {
        public Category()
        {
            Flat = new HashSet<Flat>();
        }

        public int Id { get; set; }
        public int Name { get; set; }

        public virtual ICollection<Flat> Flat { get; set; }
    }
}
