using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class User : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string type { get; set; }

    }
}
