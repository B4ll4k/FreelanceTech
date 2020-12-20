using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class Job
    {
        [Key]
        public string jobId { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double startPrice { get; set; }
        public double endPrice { get; set; }
        public string level { get; set; }
        public double Payment_Amount { get; set; }
        public string customerId { get; set; }
        public Customer Customer { get; set; }
        public int freelancerId { get; set; }
        public Freelancer Freelancer { get; set; }
        public int contractId { get; set; }
        public Contract Contract { get; set; }
        public string businessAnalystId { get; set; }
        public List<Proposal> Proposal { get; set; }
        public string comment { get; set; }
        public int rate { get; set; }
        public string description { get; set; }
        public DateTime postedDate { get; set; }
        public List<JobSkill> JobSkill { get; set; }

    }
}
