using SimpleToDo.Models.Domain;
using SimpleToDo.WebApp.Models.View;
using SimpleToDo.WebApp.Services.Interfaces;
using System;
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
                mockList.Add(CreateMockObject());
        }

        public Task<ToDoTask> Get(Guid id)
        {
            Random r = new Random();
            return Task.FromResult(CreateMockObject());
        }

        public Task<ToDoTask> Create(CreateTaskViewModel toDoTask)
        {
            return Task.FromResult(CreateMockObject());
        }

        public Task<ToDoTask> Update(Guid id, EditTaskViewModel model)
        {
            return Task.FromResult(CreateMockObject());
        }

        public Task Delete(Guid id)
        {
            return Task.CompletedTask;
        }

        private ToDoTask CreateMockObject()
        {
            Random r = new Random();
            return new ToDoTask(Guid.NewGuid().ToString(),
                string.Empty,
                DateTime.Now.AddDays(r.Next(1, 5)),
                (TaskPriority)r.Next(0, 2));
        }
    }
}