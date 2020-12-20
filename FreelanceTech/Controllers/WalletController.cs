using FreelanceTech.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceTech.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletRepository walletRepository;

        public WalletController(IWalletRepository walletRepository)
        {
            this.walletRepository = walletRepository;
        }

    }
}
