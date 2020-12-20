using FreelanceTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class SqlProposalRepository : IProposalRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SqlProposalRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool SubmitProposal(Proposal proposal)
        {
            dbContext.Add(proposal);
            dbContext.SaveChanges();
            return true;
        }
    }
}
