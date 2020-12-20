using FreelanceTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Models
{
    public class SqlWalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SqlWalletRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public Wallet Balance(int Id)
        {
            return applicationDbContext.Wallet.Find(Id);
        }

        public bool Deposit(Wallet wallet)
        {
            Wallet oldWallet = applicationDbContext.Wallet.Find(wallet.userId);
            wallet.balance += oldWallet.balance;
            applicationDbContext.Add(wallet);
            applicationDbContext.SaveChanges();
            return true;
        }
    }
}
