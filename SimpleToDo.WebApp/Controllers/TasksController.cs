using Microsoft.AspNetCore.Mvc;
using SimpleToDo.WebApp.Models.Domain;
using SimpleToDo.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleToDo.WebApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: Tasks?page=1&tasksPerPage=20
        public async Task<IActionResult> Index([FromQuery]int page = 1, [FromQuery]int tasksPerPage = 20)
        {
            List<ToDoTask> tasks = await _taskService.GetPage(page, tasksPerPage);
            return View(tasks);
        }
    }
}