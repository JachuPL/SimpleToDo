using AutoMapper;
using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;

namespace SimpleToDo.AutoMapper
{
    public class ToDoTaskProfile : Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<ToDoTask, TaskListElementViewModel>();
            CreateMap<ToDoTask, TaskDetailsViewModel>();
            CreateMap<EditTaskViewModel, ToDoTask>();
            CreateMap<CreateTaskViewModel, ToDoTask>()
                .ForMember(x => x.Id, o => o.Ignore());
        }
    }
}