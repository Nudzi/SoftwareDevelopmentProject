using System.Collections.Generic;

namespace Agency.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public int Quadrature { get; set; }

        public int FaltId { get; set; }
        public virtual Flat Falt { get; set; }

        public virtual List<Picture> Pictures { get; set; }
    }
}
