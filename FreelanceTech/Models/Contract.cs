using System.ComponentModel.DataAnnotations;
using System;



namespace FreelanceTech.Models
{
    public class Contract
    {
        [Key]
        public string contractId { get; set; }
        public string file { get; set; }
        public string jobId { get; set; }
        public Job Job { get; set; }
        public DateTime signedDate { get; set; }
    }
}
