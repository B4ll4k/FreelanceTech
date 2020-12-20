using System.ComponentModel.DataAnnotations;

namespace FreelanceTech.Models
{
    public class Wallet
    {
        [Key]
        public string userId { get; set; }
        public double balance { get; set; }
    }
}
