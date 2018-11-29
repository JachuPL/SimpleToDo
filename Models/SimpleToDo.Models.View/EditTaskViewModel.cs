using SimpleToDo.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleToDo.Models.View
{
    public class EditTaskViewModel
    {
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Przewid. termin zakończenia")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Status")]
        public TaskStatus Status { get; set; }

        [Display(Name = "Priorytet")]
        public TaskPriority Priority { get; set; }
    }
}