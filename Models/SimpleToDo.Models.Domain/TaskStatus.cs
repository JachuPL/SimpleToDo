using System.ComponentModel.DataAnnotations;

namespace SimpleToDo.Models.Domain
{
    public enum TaskStatus
    {
        [Display(Name = "Nieukończone")]
        Unfinished,

        [Display(Name = "Ukończone")]
        Finished
    }
}