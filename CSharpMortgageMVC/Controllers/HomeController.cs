using CSharpMortgageMVC.Helper;
using CSharpMortgageMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSharpMortgageMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult App()
        {
            Loan loan = new Loan()
            {
                Payment = 0.0m,
                TotalInterest = 0.0m,
                TotalCost = 0.0m,
                InterestRate = 3.5m,
                LoanAmount = 15000,
                TermMonths = 60
            };
            
            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult App(Loan loan)
        {
            //calculate the loan
            LoanHelper loanHelper = new();

            var loanHelperView = loanHelper.GetPayments(loan);

            return(View(loanHelperView));
        }

        [HttpPost]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}