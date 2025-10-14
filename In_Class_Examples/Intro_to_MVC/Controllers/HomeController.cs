using Intro_to_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Intro_to_MVC.Controllers
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

        public IActionResult About()
        {
            Developer dev = new Developer
            {
                Name = "Professor Ackerman",
                Email = "adam@ou.edu",
                InterestingFact = "I love to teach!"
            };
            // ViewData["Developer"] = dev;

            Developer dev2 = new Developer
            {
                Name = "Jane Doe",
                Email = "",
                InterestingFact = "I love to code!"
            };

            List<Developer> devs = new List<Developer> { dev, dev2 };

            return View(devs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
