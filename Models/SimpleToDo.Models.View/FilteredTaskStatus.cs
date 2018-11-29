using System.ComponentModel.DataAnnotations;

namespace SimpleToDo.Models.View
{
    public enum FilteredTaskStatus
    {
        [Display(Name = "Nieukończone")]
        Unfinished = 0,

        [Display(Name = "Ukończone")]
        Finished = 1,

        [Display(Name = "Wszystkie")]
        All
    }
}