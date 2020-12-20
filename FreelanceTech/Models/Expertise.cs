using System.ComponentModel.DataAnnotations;


namespace FreelanceTech.Models
{
    
    public class Expertise
    {
        public int id { get; set; }
        public string freelancerId { get; set; }
        public int category { get; set; }
        public int skill  { get; set; }
        public string status { get; set; }
        public string level { get; set; }
    }
}
