using System.Collections.Generic;

namespace SimpleToDo.Models.View
{
    public class SearchResultsViewModel
    {
        public List<TaskListElementViewModel> Results { get; set; } = new List<TaskListElementViewModel>();
        public string Phrase { get; set; }
    }
}