namespace Agency.Models
{
    public partial class Picture
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
