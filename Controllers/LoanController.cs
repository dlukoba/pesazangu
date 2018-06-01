using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

using pesazangu.Models;

namespace pesazangu.Controllers
{
    public class LoanController : Controller
    {
        readonly IScoreProductSuitability scoreProductSuitability;

        public LoanController(IScoreProductSuitability scoreProductSuitability)
        {
            this.scoreProductSuitability = scoreProductSuitability;
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
            var response = new CompareResultViewModel
            {
                LoanAmount = model.LoanAmount
            };

            var values = scoreProductSuitability.Score(null, new LoanConstraints()
            {
                Amount = model.LoanAmount,
                RepaymentPeriodInDays = model.PaybackDuration
            });

            return PartialView("PartialCompare", response);
        }
    }
}