using System;

namespace SimpleToDo.Models.Domain
{
    public class ToDoTask
    {
        public ToDoTask(string title, string description, DateTime dueDate, TaskPriority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = TaskStatus.Finished;
            Priority = priority;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
    }
}