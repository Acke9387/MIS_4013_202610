using Microsoft.AspNetCore.Mvc;

namespace Intro_to_MVC.Controllers
{
    public class PriceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MIS()
        {
            return View();
        }
    }
}
