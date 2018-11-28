using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;
using SimpleToDo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

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
        public async Task<IActionResult> Index([FromQuery]int page = 1, [FromQuery]int tasksPerPage = 10)
        {
            IPagedList<ToDoTask> tasks = await _taskService.GetPage(page, tasksPerPage);
            return View(tasks);
        }

        // GET: Tasks/{id:guid}
        public async Task<IActionResult> Details(Guid id)
        {
            ToDoTask task = await _taskService.Get(id);
            if (task is null)
                return RedirectToAction(nameof(Index));

            return View(ToDetailsViewModel(task));
        }

        private TaskDetailsViewModel ToDetailsViewModel(ToDoTask task)
        {
            return new TaskDetailsViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Finished = task.Finished,
                Priority = task.Priority,
                DueDate = task.DueDate,
                Description = task.Description
            };
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            ToDoTask newTask = await _taskService.Create(viewModel);
            return RedirectToAction(nameof(Details), new { id = newTask.Id });
        }

        // GET: Tasks/Edit/{id:guid}
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Index));

            ToDoTask task = await _taskService.Get(id.Value);
            if (task is null)
                return RedirectToAction(nameof(Index));

            EditTaskViewModel model = new EditTaskViewModel
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Finished = task.Finished
            };

            return View(model);
        }

        // POST: Tasks/Edit/{id:guid}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid? id, EditTaskViewModel model)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
                return View(model);

            ToDoTask task = await _taskService.Update(id.Value, model);
            if (task is null)
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Details), new { id = task.Id });
        }

        // POST: Tasks/Delete/{id:guid}
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Index));

            await _taskService.Delete(id.Value);

            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Search
        public IActionResult Search()
        {
            return View(new SearchResultsViewModel());
        }

        // POST: Tasks/Search
        [HttpPost]
        public async Task<IActionResult> Search(SearchCriteriaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(new SearchResultsViewModel());

            model.Phrase = model.Phrase.Trim();
            List<ToDoTask> results = await _taskService.FindMatchingTitlesOrDescriptions(model.Phrase);
            List<TaskIndexViewModel> taskIndex = new List<TaskIndexViewModel>();
            results.ForEach(task =>
            {
                TaskIndexViewModel indexModel = new TaskIndexViewModel
                {
                    Id = task.Id,
                    Finished = task.Finished,
                    Priority = task.Priority,
                    Title = task.Title,
                    DueDate = task.DueDate
                };
                taskIndex.Add(indexModel);
            });
            SearchResultsViewModel resultsModel = new SearchResultsViewModel()
            {
                Phrase = model.Phrase,
                Results = taskIndex
            };
            return View(nameof(Search), resultsModel);
        }
    }
}