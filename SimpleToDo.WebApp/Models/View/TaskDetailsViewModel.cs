using SimpleToDo.Models.Domain;
using System;

namespace SimpleToDo.WebApp.Models.View
{
    public class TaskDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Finished { get; set; }
        public TaskPriority Priority { get; set; }
    }
}