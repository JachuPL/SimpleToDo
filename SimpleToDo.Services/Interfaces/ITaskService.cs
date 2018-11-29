using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
using TaskStatus = SimpleToDo.Models.Domain.TaskStatus;

namespace SimpleToDo.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IPagedList<ToDoTask>> GetPage(int page, int tasksPerPage, TaskStatus filteredStatus);

        Task<ToDoTask> Get(Guid id);

        Task<ToDoTask> Create(ToDoTask toDoTask);

        Task<ToDoTask> Update(Guid id, EditTaskViewModel model);

        Task Delete(Guid id);

        Task<List<ToDoTask>> FindMatchingTitlesOrDescriptions(string criteria);
    }
}