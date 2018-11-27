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
            FillWithSomeObjects(mockList);
            return Task.FromResult(mockList);
        }

        private void FillWithSomeObjects(List<ToDoTask> mockList)
        {
            Random r = new Random();
            int max = r.Next(10, 20);
            for (int i = 0; i < max; i++)
                mockList.Add(new ToDoTask());
        }
    }
}