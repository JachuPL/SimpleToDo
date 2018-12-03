using SimpleToDo.Models.Domain;
using System;

namespace SimpleToDo.Models.View
{
    public static class FilteredTaskStatusExtensions
    {
        public static TaskStatus ToTaskStatus(this FilteredTaskStatus filteredStatus)
        {
            switch (filteredStatus)
            {
                case FilteredTaskStatus.Finished:
                    return TaskStatus.Finished;

                case FilteredTaskStatus.Unfinished:
                    return TaskStatus.Unfinished;

                case FilteredTaskStatus.All:
                default:
                    throw new InvalidCastException("No such value in other enum");
            }
        }
    }
}