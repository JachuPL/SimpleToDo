using Microsoft.EntityFrameworkCore;
using SimpleToDo.Database;
using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;
using SimpleToDo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleToDo.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoContext _ctx;

        public TaskService(ToDoContext context)
        {
            _ctx = context;
        }

        public Task<List<ToDoTask>> GetPage(int page, int tasksPerPage)
        {
            return _ctx.Tasks
                .OrderBy(x => x.Finished)
                .ThenByDescending(x => x.Priority)
                .Skip((page - 1) * tasksPerPage).Take(tasksPerPage)
                .ToListAsync();
        }

        public async Task<ToDoTask> Get(Guid id)
        {
            return await _ctx.Tasks.FindAsync(id);
        }

        public async Task<ToDoTask> Create(CreateTaskViewModel toDoTask)
        {
            ToDoTask task = new ToDoTask(toDoTask.Title, toDoTask.Description, toDoTask.DueDate, toDoTask.Priority);
            task.Finished = toDoTask.Finished;

            task = _ctx.Tasks.Add(task).Entity;
            await _ctx.SaveChangesAsync();
            return task;
        }

        public async Task<ToDoTask> Update(Guid id, EditTaskViewModel model)
        {
            ToDoTask task = await Get(id);
            if (task is null)
                return null;

            task.Title = model.Title;
            task.Description = model.Description;
            task.Finished = model.Finished;
            task.DueDate = model.DueDate;
            task.Priority = model.Priority;

            _ctx.Tasks.Update(task);
            await _ctx.SaveChangesAsync();
            return task;
        }

        public async Task Delete(Guid id)
        {
            ToDoTask task = await Get(id);
            if (task is null)
                return;

            _ctx.Tasks.Remove(task);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<ToDoTask>> FindMatchingTitlesOrDescriptions(string criteria)
        {
            return await _ctx.Tasks.Where(x => x.Title.Contains(criteria) || x.Description.Contains(criteria)).ToListAsync();
        }
    }
}