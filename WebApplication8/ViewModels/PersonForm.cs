using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

 namespace WebApplication8.ViewModel
{
    public class PersonForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNNumber { get; set; }
        public bool Verified { get; set; }
       
    }
}
