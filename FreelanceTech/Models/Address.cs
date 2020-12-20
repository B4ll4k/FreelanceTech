using System.ComponentModel.DataAnnotations;

namespace FreelanceTech.Models
{
    public class Address
    {
        [Key]
        public string userId { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string woreda { get; set; }
        public int houseNumber { get; set; }
        public int pobox { get; set; }
    }
}
