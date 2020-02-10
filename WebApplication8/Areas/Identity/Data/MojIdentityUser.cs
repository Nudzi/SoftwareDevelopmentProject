using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Agency.Models;
using Microsoft.AspNetCore.Identity;

namespace WebApplication8.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MojIdentityUser class
    public class MojIdentityUser : IdentityUser
    {
        // Add columns
        
        // Add users 
        public Employee Employee { get; set; }
        public virtual Client Client { get; set; }
        public virtual PersonDetail PersonDetail { get; set; }

    }
}
