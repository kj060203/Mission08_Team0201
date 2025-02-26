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
            //Linq
            var tasks = _context.Tasks
                .Where(x => x.Completed == false)
                .OrderBy(x => x.TaskName).ToList();
        
            return View(tasks);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);
        
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View("EnterTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
            return RedirectToAction("ViewTask");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == id);
        
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return RedirectToAction("ViewTask");
        }
        
    }
}
