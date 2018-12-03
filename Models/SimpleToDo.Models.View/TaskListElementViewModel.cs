using SimpleToDo.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleToDo.Models.View
{
    public class TaskListElementViewModel
    {
        [Display(Name = "Identyfikator")]
        public Guid Id { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }

        [Display(Name = "Przewid. termin zakończenia")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Priorytet")]
        public TaskPriority Priority { get; set; }

        public string GetClassByPriority()
        {
            switch (Priority)
            {
                case TaskPriority.Normal:
                    return "table-default";

                case TaskPriority.High:
                    return "table-warning";

                case TaskPriority.Critical:
                default:
                    return "table-danger";
            }
        }
    }
}