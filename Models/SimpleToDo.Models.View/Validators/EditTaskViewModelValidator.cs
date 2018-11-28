using FluentValidation;
using SimpleToDo.Models.Domain;

namespace SimpleToDo.Models.View.Validators
{
    public class EditTaskViewModelValidator : AbstractValidator<EditTaskViewModel>
    {
        public EditTaskViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Wprowadź nazwę zadania.")
                .MinimumLength(2).WithMessage("Nazwa zadania powinna zawierać co najmniej 2 znaki.")
                .MaximumLength(100).WithMessage("Nazwa zadania powinna zawierać maksymalnie 100 znaków.");

            RuleFor(x => x.Description)
                .MinimumLength(2).WithMessage("Opis zadania powinien zawierać co najmniej 2 znaki.");

            RuleFor(x => x.DueDate)
                .NotEmpty().WithMessage("Podaj przewidywaną datę zakończenia zadania.");

            RuleFor(x => x.Priority)
                .Must(BeAValidValue)
                .WithMessage(
                    "Wartościami dozwolonymi dla priorytetu zadania są \"Normalny\", \"Wysoki\" oraz \"Krytyczny\".");
        }

        private bool BeAValidValue(TaskPriority parsedPriority)
        {
            return TaskPriority.Normal <= parsedPriority && parsedPriority <= TaskPriority.Critical;
        }
    }
}