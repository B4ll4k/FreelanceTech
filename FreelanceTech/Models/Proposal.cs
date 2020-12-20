using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FreelanceTech.Models
{
    public class Proposal
    {
            
            public int proposalId { get; set; }
            public int jobId { get; set; }
            public int freelancerId { get; set; }
            public int cusomerId { get; set; }
            public string cover { get; set; }
            public string description { get; set; }

    }
}
