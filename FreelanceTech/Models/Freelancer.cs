using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreelanceTech.Models
{
    public class Freelancer
{
        [Key]
        public string freelancerId { get; set; }
        public string phoneNumber { get; set; }
        public Expertise Expertise { get; set; }
        public string education { get; set; }
        public int id { get; set; }
        public Experience Experience { get; set; }
        public List<Language> Language { get; set; }
        public int englishProficiency { get; set; }
        public double hourlyRate { get; set; }
        public string title { get; set; }
        public string professionalOverview { get; set; }
        public string photo { get; set; }
        public Address Address { get; set; }
        public Wallet Wallet { get; set; }
        public List<Transaction> Transaction { get; set; }
        public List<Job> Job { get; set; }
        public List<Proposal> Proposal { get; set; }
        public string legaID { get; set; }
        public double rate { get; set; }
        public double score { get; set; }
        public int status { get; set; }

    }
}
