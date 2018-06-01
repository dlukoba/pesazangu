using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

using pesazangu.Models;
using System.Linq;

namespace pesazangu.Controllers
{
    public class LoanController : Controller
    {
        readonly IScoreProductSuitability scoreProductSuitability;
        readonly IRepository repository;

        public LoanController(IScoreProductSuitability scoreProductSuitability, IRepository repository)
        {
            this.scoreProductSuitability = scoreProductSuitability;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Compare()
        {
            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Days", Value = "1", Selected = true },
                new SelectListItem() { Text = "Weeks", Value = "2" },
                new SelectListItem() { Text = "Months", Value = "3" },
            };
            var model = new CompareViewModel 
            {
                PaybackDurationTypes = items
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ResponseCache(NoStore = true, Duration = 0)]
        public IActionResult Compare(CompareViewModel model) 
        {
            var values = scoreProductSuitability.Score(repository.Products, new LoanConstraints()
            {
                Amount = model.LoanAmount,
                RepaymentPeriodInDays = model.PaybackDuration
            });

            var viewModel = values.Join(repository.Vendors, c => c.Product.VendorId, v => v.Id, (c, d) =>
            new CompareResultViewModel
            {
                VendorId = d.Id,
                VendorName = d.Name,
                ProductId = c.Product.Id,
                ProductShortDesc = c.Product.ShortDesc,
                LoanAmount = model.LoanAmount,
                RepayableAmount = c.Product.GetRepayableAmount(model.LoanAmount),
                Score = c.Score,
                MaxRepaymentPeriodInDays = c.Product.RepaymentPeriodInDays
            });

            return PartialView("PartialCompare", viewModel);
        }
    }
}