using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class Transaction
    {
        public string transactionId { get; set; }
        public string userId { get; set; }
        public double amount { get; set; }
        public DateTime time { get; set; }

    }
}
