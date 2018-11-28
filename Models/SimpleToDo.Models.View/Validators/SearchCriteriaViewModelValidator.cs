using FluentValidation;

namespace SimpleToDo.Models.View.Validators
{
    public class SearchCriteriaViewModelValidator : AbstractValidator<SearchCriteriaViewModel>
    {
        public SearchCriteriaViewModelValidator()
        {
            RuleFor(x => x.Phrase).NotEmpty().WithMessage("Wprowadź frazę do wyszukania.");
        }
    }
}