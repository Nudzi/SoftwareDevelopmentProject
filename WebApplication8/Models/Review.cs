using System;
using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int Raiting { get; set; }
        public string Description { get; set; }
        public int FlatId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
