﻿using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Models.Domain;
using SimpleToDo.WebApp.Models.View;
using SimpleToDo.WebApp.Services.Interfaces;
using System;
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
            List<TaskIndexViewModel> taskIndex = new List<TaskIndexViewModel>();
            tasks.ForEach(task =>
            {
                TaskIndexViewModel model = new TaskIndexViewModel
                {
                    Id = task.Id,
                    Finished = task.Finished,
                    Priority = task.Priority,
                    Title = task.Title,
                    DueDate = task.DueDate
                };
                taskIndex.Add(model);
            });
            return View(taskIndex);
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

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            ToDoTask newTask = await _taskService.Create(viewModel);
            return RedirectToAction(nameof(Details), new { id = newTask.Id });
        }

        // GET: Task/Edit/{id:guid}
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

        // POST: Task/Edit/{id:guid}
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

        // POST: Task/Delete/{id:guid}
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (!id.HasValue)
                return RedirectToAction(nameof(Index));

            await _taskService.Delete(id.Value);

            return RedirectToAction(nameof(Index));
        }
    }
}