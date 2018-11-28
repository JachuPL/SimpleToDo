using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace SimpleToDo.WebApp.Binders
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder = new DateTimeModelBinder("dd.MM.yyyy HH:mm:ss");

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}