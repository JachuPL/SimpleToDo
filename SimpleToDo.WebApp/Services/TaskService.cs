using SimpleToDo.WebApp.Models.Domain;
using SimpleToDo.WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleToDo.WebApp.Services
{
    public class TaskService : ITaskService
    {
        public Task<List<ToDoTask>> GetPage(int page, int tasksPerPage)
        {
            List<ToDoTask> mockList = new List<ToDoTask>();
            return Task.FromResult(mockList);
        }
    }
}