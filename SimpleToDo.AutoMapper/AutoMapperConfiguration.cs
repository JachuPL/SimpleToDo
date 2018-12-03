using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleToDo.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(IServiceCollection services)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ToDoTaskProfile>();
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}