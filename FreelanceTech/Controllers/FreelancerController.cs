using FreelanceTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YenePaySdk;

namespace FreelanceTech.Controllers
{
    public class FreelancerController : Controller
    {
        private readonly IProposalRepository proposalRepository;
        private readonly IWalletRepository walletRepository;
        private CheckoutOptions checkoutoptions;
        private string pdtToken = "APnMhGcBqU8Nfw";
        private readonly ILogger<HomeController> _logger;
        public Wallet _wallet;

        public FreelancerController(ILogger<HomeController> logger = null, IProposalRepository proposalRepository = null, IWalletRepository walletRepository = null)
        {
            _logger = logger;
            this.proposalRepository = proposalRepository;
            this.walletRepository = walletRepository;
            string sellerCode = "0778";
            string successUrlReturn = "https://localhost:44346/Freelancer/Deposittowallet"; //"YOUR_SUCCESS_URL";
            string ipnUrlReturn = "https://localhost:44346/Freelancer/IPNDestination"; //"YOUR_IPN_URL";
            string cancelUrlReturn = "https://localhost:44346/Freelancer/PaymentCancelReturnUrl"; //"YOUR_CANCEL_URL";
            string failureUrlReturn = ""; //"YOUR_FAILURE_URL";
            bool useSandBox = true;
            checkoutoptions = new CheckoutOptions(sellerCode, string.Empty, CheckoutType.Express, useSandBox, null, successUrlReturn, cancelUrlReturn, ipnUrlReturn, failureUrlReturn);

        }

        //public FreelancerController(IProposalRepository proposalRepository)
        //{
        //    this.proposalRepository = proposalRepository;
        //}
        //public FreelancerController(IWalletRepository walletRepository)
        //{
        //    this.walletRepository = walletRepository;
        //}
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SubmitProposal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitProposal(Proposal proposal)
        {
            if (ModelState.IsValid)
            {
                proposal.proposalId = 1;
                proposal.jobId = 1;
                proposal.freelancerId = 1;
                proposal.cusomerId = 1;
                proposalRepository.SubmitProposal(proposal);
                return View();
            }
            return View();
        }
        [HttpGet]
        public IActionResult DepositToWallet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DepositToWallet(Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                //CheckoutExpress(wallet);
                walletRepository.Deposit(wallet);
                return View();
            }
            return View();
        }
        [HttpPost]
        public void CheckoutExpress(Wallet wallet)
        {
            Random random = new Random();
            int num = random.Next(1, 30000);
            _wallet = new Wallet();
            _wallet.userId = num.ToString();
            _wallet.balance = Double.Parse(Request.Form["balance"]);
            checkoutoptions.Process = CheckoutType.Express;
            Random rnd = new Random();
            int Id = rnd.Next(1, 10000);
            var itemId = Convert.ToString(Id);
            var itemName = "Deposit To Freelance Tech Wallet";
            var unitPrice = decimal.Parse(Request.Form["balance"]);
            //var quantity = int.Parse(Request.Form["Quantity"]);
            //var discount = decimal.Parse(Request.Form["Discount"]);
            //var deliveryFee = decimal.Parse(Request.Form["DeliveryFee"]);
            //var handlingFee = decimal.Parse(Request.Form["HandlingFee"]);
            //var tax1 = decimal.Parse(Request.Form["Tax1"]);
            //var tax2 = decimal.Parse(Request.Form["Tax2"]);

            CheckoutItem checkoutitem = new CheckoutItem(itemId, itemName, unitPrice, 1, null, null, null, null, null);
            checkoutoptions.OrderId = null; //"YOUR_UNIQUE_ID_FOR_THIS_ORDER";  //can also be set null
            checkoutoptions.ExpiresAfter = 2880; //"NUMBER_OF_MINUTES_BEFORE_THE_ORDER_EXPIRES"; //setting null means it never expires
            var url = CheckoutHelper.GetCheckoutUrl(checkoutoptions, checkoutitem);
            Response.Redirect(url);
            RedirectToAction("DepositToWallet", _wallet);
        }
        [HttpPost]
        public async Task<string> IPNDestination(IPNModel ipnModel)
        {
            var result = string.Empty;
            ipnModel.UseSandbox = checkoutoptions.UseSandbox;
            if (ipnModel != null)
            {
                var isIPNValid = await CheckIPN(ipnModel);

                if (isIPNValid)
                {
                    //This means the payment is completed
                    //You can now mark the order as "Paid" or "Completed" here and start the delivery process
                }
            }
            return result;
        }

        public async Task<ActionResult> PaymentSuccessReturnUrl(IPNModel ipnModel)
        {
            PDTRequestModel model = new PDTRequestModel(pdtToken, ipnModel.TransactionId, ipnModel.MerchantOrderId);
            model.UseSandbox = checkoutoptions.UseSandbox;
            var pdtResponse = await CheckoutHelper.RequestPDT(model);
            if (pdtResponse.Count() > 0)
            {
                if (pdtResponse["Status"] == "Paid")
                {
                    //This means the payment is completed. 
                    //You can extract more information of the transaction from the pdtResponse dictionary
                    //You can now mark the order as "Paid" or "Completed" here and start the delivery process
                }
            }
            else
            {
                //This means the pdt request has failed.
                //possible reasons are 
                //1. the TransactionId is not valid
                //2. the PDT_Key is incorrect
            }
            return RedirectToAction("DepositToWallet", _wallet);
        }

        public async Task<string> PaymentCancelReturnUrl(IPNModel ipnModel)
        {
            PDTRequestModel model = new PDTRequestModel(pdtToken, ipnModel.TransactionId, ipnModel.MerchantOrderId);
            var pdtResponse = await CheckoutHelper.RequestPDT(model);
            if (pdtResponse.Count() > 0)
            {
                if (pdtResponse["Status"] == "Canceled")
                {
                    //This means the payment is canceled. 
                    //You can extract more information of the transaction from the pdtResponse dictionary
                    //You can now mark the order as "Canceled" here.
                }
            }
            else
            {
                //This means the pdt request has failed.
                //possible reasons are 
                //1. the TransactionId is not valid
                //2. the PDT_Key is incorrect
            }
            return string.Empty;
        }
        private async Task<bool> CheckIPN(IPNModel model)
        {
            return await CheckoutHelper.IsIPNAuthentic(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
