using X.PagedList;

namespace SimpleToDo.Models.View
{
    public class TaskIndexViewModel
    {
        public IPagedList<TaskListElementViewModel> Tasks { get; set; }
        public TaskStatus FilteredStatus { get; set; }
    }
}