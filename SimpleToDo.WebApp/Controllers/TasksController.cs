using AutoMapper;
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
        private readonly IMapper _mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        // GET: Tasks?page=1
        public async Task<IActionResult> Index([FromQuery]int page = 1)
        {
            IPagedList<ToDoTask> tasks = await _taskService.GetPage(page, 10);
            return View(ToMappedPagedList<ToDoTask, TaskIndexViewModel>(tasks));
        }

        private IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;
        }

        // GET: Tasks/{id:guid}
        public async Task<IActionResult> Details(Guid id)
        {
            ToDoTask task = await _taskService.Get(id);
            if (task is null)
                return RedirectToAction(nameof(Index));

            return View(_mapper.Map<TaskDetailsViewModel>(task));
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

            ToDoTask newTask = await _taskService.Create(_mapper.Map<ToDoTask>(viewModel));
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

            return View(_mapper.Map<EditTaskViewModel>(task));
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
            List<ToDoTask> searchResults = await _taskService.FindMatchingTitlesOrDescriptions(model.Phrase);

            SearchResultsViewModel resultsModel = new SearchResultsViewModel()
            {
                Phrase = model.Phrase,
                Results = _mapper.Map<List<TaskIndexViewModel>>(searchResults)
            };
            return View(nameof(Search), resultsModel);
        }
    }
}