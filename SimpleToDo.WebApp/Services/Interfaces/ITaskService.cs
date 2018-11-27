using SimpleToDo.WebApp.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleToDo.WebApp.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<ToDoTask>> GetPage(int page, int tasksPerPage);

        Task<ToDoTask> Get(Guid id);
    }
}