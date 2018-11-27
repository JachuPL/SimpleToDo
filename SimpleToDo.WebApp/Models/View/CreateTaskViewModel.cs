using SimpleToDo.WebApp.Models.Domain;
using System;

namespace SimpleToDo.WebApp.Models.View
{
    public class CreateTaskViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Finished { get; set; }
        public TaskPriority Priority { get; set; }
    }
}