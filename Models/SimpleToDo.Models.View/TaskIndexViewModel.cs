using SimpleToDo.Models.Domain;
using System;

namespace SimpleToDo.Models.View
{
    public class TaskIndexViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Finished { get; set; }
        public DateTime DueDate { get; set; }
        public TaskPriority Priority { get; set; }
    }
}