using Microsoft.AspNetCore.Mvc;

namespace pesazangu.Controllers
{
    public class LoanController : Controller
    {
        public LoanController() { }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Compare()
        {
            return View();
        }
    }
}