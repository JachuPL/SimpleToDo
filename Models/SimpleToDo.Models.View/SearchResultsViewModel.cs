using System.Collections.Generic;

namespace SimpleToDo.Models.View
{
    public class SearchResultsViewModel
    {
        public List<TaskIndexViewModel> Results { get; set; } = new List<TaskIndexViewModel>();
        public string Phrase { get; set; }
    }
}