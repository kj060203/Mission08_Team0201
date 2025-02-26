using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0201.Models;
using Mission08_Team0201.Views.Home;

namespace Mission08_Team0201.Controllers
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

        public IActionResult EnterTask()
        {
            return View();
        }

        public IActionResult ViewTask()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
