using System.ComponentModel.DataAnnotations;

namespace SimpleToDo.Models.Domain
{
    public enum TaskPriority
    {
        [Display(Name = "Normalny")]
        Normal,

        [Display(Name = "Wysoki")]
        High,

        [Display(Name = "Krytyczny")]
        Critical
    }
}