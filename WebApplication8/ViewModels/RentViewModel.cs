using System;
using System.ComponentModel.DataAnnotations;

namespace Agency.ViewModels
{
    public class RentViewModel
    {
        public RentViewModel()
        {
            PersonDetails = new RentPersonDetailViewModel();
        }

        public int Id { get; set; }
        public int FlatId { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime From { get; set; }

        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime To { get; set; }

        public string FlatTitle { get; set; }

        public string MojIdentityUserId { get; set; }

        public RentPersonDetailViewModel PersonDetails { get; set; }
    }
}
