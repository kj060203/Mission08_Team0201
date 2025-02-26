using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0201.Models;
using Mission08_Team0201.Views.Home;
using Task = Mission08_Team0201.Models.Task;

namespace Mission08_Team0201.Controllers
{
    public class HomeController : Controller
    {
        private Mission08DbContext _context;

        public HomeController(Mission08DbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult EnterTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(new Task());
        }

        [HttpPost]

        public IActionResult EnterTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task); //add record to db
                _context.SaveChanges(); //save changes
        
                return View("Index", task);
            }
            else //invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                return View("EnterTask", task);
            }
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
