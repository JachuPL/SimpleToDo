using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace SimpleToDo.WebApp.Binders
{
    public class DateTimeModelBinder : IModelBinder
    {
        private string _customFormat;

        public DateTimeModelBinder(string customFormat)
        {
            _customFormat = customFormat;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            object actualValue = null;
            try
            {
                if (valueResult.FirstValue != "")
                    actualValue = DateTime.ParseExact(valueResult.FirstValue, _customFormat,
                        CultureInfo.InvariantCulture);
                else
                    actualValue = null;
            }
            catch (FormatException)
            {
                actualValue = null;
            }

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, actualValue, valueResult.FirstValue);
            bindingContext.Result = ModelBindingResult.Success(actualValue);
            return Task.CompletedTask;
        }
    }
}