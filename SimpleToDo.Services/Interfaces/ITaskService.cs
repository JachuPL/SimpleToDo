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
        Task<IPagedList<ToDoTask>> GetPage(int page, int tasksPerPage);

        Task<ToDoTask> Get(Guid id);

        Task<ToDoTask> Create(CreateTaskViewModel toDoTask);

        Task<ToDoTask> Update(Guid id, EditTaskViewModel model);

        Task Delete(Guid id);

        Task<List<ToDoTask>> FindMatchingTitlesOrDescriptions(string criteria);
    }
}