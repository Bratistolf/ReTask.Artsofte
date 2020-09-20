using FluentValidation;

namespace ReTask.Artsofte.Application.CQRS.Languages.Commands.Edit
{
    public class LanguageEditCommandValidator : AbstractValidator<LanguageEditCommand>
    {
        public LanguageEditCommandValidator()
        {
            RuleFor(command => command.Name).MinimumLength(1).WithMessage("'name' is too short.")
                                            .MaximumLength(64).WithMessage("'name' is too long.")
                                            .OverridePropertyName("name");
        }
    }
}
