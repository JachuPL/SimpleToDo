using System.ComponentModel.DataAnnotations;

namespace SimpleToDo.Models.Domain
{
    public enum TaskStatus
    {
        [Display(Name = "Nieukończone")]
        Unfinished = 0,

        [Display(Name = "Ukończone")]
        Finished = 1
    }
}