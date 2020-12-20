using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FreelanceTech.Models
{
    public class Experience
    {
        [Key]
        public string id { get; set; }
        public string freelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public string companyName { get; set; }
        public string location { get; set; }
        public string title { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }
    }

}
