﻿using System;

namespace SimpleToDo.WebApp.Models.Domain
{
    public class ToDoTask
    {
        public ToDoTask(string title, string description, DateTime dueDate, TaskPriority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Finished = false;
            Priority = priority;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Finished { get; set; }
        public TaskPriority Priority { get; set; }
    }
}