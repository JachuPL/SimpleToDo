using AutoMapper;
using SimpleToDo.Models.Domain;
using SimpleToDo.Models.View;

namespace SimpleToDo.AutoMapper
{
    public class ToDoTaskProfile : Profile
    {
        public ToDoTaskProfile()
        {
            CreateMap<ToDoTask, TaskIndexViewModel>();
            CreateMap<ToDoTask, TaskDetailsViewModel>();
            CreateMap<EditTaskViewModel, ToDoTask>();
        }
    }
}