using Microsoft.EntityFrameworkCore;
using SimpleToDo.Database;
using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;
using SimpleToDo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SimpleToDo.Services
{
    public class TaskService : ITaskService
    {
        private readonly ToDoContext _ctx;

        public TaskService(ToDoContext context)
        {
            _ctx = context;
        }

        public Task<IPagedList<ToDoTask>> GetPage(int page, int tasksPerPage, FilteredTaskStatus filteredStatus)
        {
            IQueryable<ToDoTask> query = _ctx.Tasks;

            if (filteredStatus != FilteredTaskStatus.All)
                query = query.Where(x => (int)x.Status == (int)filteredStatus);

            return query.OrderBy(x => x.Status)
                .ThenByDescending(x => x.Priority)
                .ToPagedListAsync(page, tasksPerPage);
        }

        public async Task<ToDoTask> Get(Guid id)
        {
            return await _ctx.Tasks.FindAsync(id);
        }

        public async Task<ToDoTask> Create(ToDoTask toDoTask)
        {
            toDoTask = _ctx.Tasks.Add(toDoTask).Entity;
            await _ctx.SaveChangesAsync();
            return toDoTask;
        }

        public async Task<ToDoTask> Update(Guid id, EditTaskViewModel model)
        {
            ToDoTask task = await Get(id);
            if (task is null)
                return null;

            task.Title = model.Title;
            task.Description = model.Description;
            task.Status = model.Status;
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