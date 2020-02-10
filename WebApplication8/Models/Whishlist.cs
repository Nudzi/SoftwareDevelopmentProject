namespace Agency.Models
{
    public partial class Whishlist
    {
        public int ClientId { get; set; }
        public int FlatId { get; set; }
        public int Id { get; set; }

        public virtual Client Client { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
