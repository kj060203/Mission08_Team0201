using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0201.Models;
using Mission08_Team0201.Views.Home;
using Task = Mission08_Team0201.Models.Task;

namespace Mission08_Team0201.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult EnterTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View(new Task());
        }

        [HttpPost]

        public IActionResult EnterTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
        
                return View("Index", task);
            }
            else //invalid data
            {
                ViewBag.Categories = _repo.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                return View("EnterTask", task);
            }
        }

        public IActionResult ViewTask()
        {
            //Linq
            var tasks = _repo.Tasks
                .Where(x => x.Completed == false)
                .OrderBy(x => x.TaskName).ToList();
        
            return View(tasks);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .SingleOrDefault(x => x.TaskId == id);
        
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();
            return View("EnterTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task task)
        {
            _repo.UpdateTask(task);
            return RedirectToAction("ViewTask");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .SingleOrDefault(x => x.TaskId == id);
        
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            _repo.DeleteTask(task);
            return RedirectToAction("ViewTask");
        }
        
        
    }
}
