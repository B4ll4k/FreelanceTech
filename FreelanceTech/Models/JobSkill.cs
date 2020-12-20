using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FreelanceTech.Models
{
    public class JobSkill
    {
        [Key]
        public int id { get; set; }
        public string jobId { get; set; }
        public Job Job { get; set; }
        public string skill { get; set; }
    }
}
