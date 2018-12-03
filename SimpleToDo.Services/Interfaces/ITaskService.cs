using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace SimpleToDo.Services.Interfaces
{
    public interface ITaskService
    {
        Task<IPagedList<ToDoTask>> GetPage(int page, int tasksPerPage, FilteredTaskStatus filteredStatus);

        Task<ToDoTask> Get(Guid id);

        Task<ToDoTask> Create(ToDoTask toDoTask);

        Task<ToDoTask> Update(ToDoTask task);

        Task Delete(Guid id);

        Task<List<ToDoTask>> FindMatchingTitlesOrDescriptions(string criteria);
    }
}