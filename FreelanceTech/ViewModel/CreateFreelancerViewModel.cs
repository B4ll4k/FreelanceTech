using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FreelanceTech.Models;

namespace FreelanceTech.ViewModel
{
    public class CreateFreelancerViewModel
    {
        public string freelancerId { get; set; }
        public string phoneNumber { get; set; }
        public string education { get; set; }
        public string hourlyRate { get; set; }
        public string title { get; set; }
        public string professionalOverview { get; set; }
        public IFormFile photo { get; set; }
        public string legaID { get; set; }
        public string status { get; set; }


        public string region { get; set; }
        public string city { get; set; }
        public string woreda { get; set; }
        public int houseNumber { get; set; }
        public int pobox { get; set; }


    
     
        public string expertiseStatus { get; set; }
        public string level { get; set; }

        public string companyName { get; set; }
        public string location { get; set; }
        public string expTitle { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string description { get; set; }

        public Constants.category category { get; set; }
        public Constants.skill skill { get; set; }
        public Constants.language language { get; set; }
        public Constants.englishProficiency englishProficiency { get; set; }
    }
}
