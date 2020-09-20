using FluentValidation;

namespace ReTask.Artsofte.Application.CQRS.Languages.Commands.Add
{
    public class LanguageAddCommandValidator : AbstractValidator<LanguageAddCommand>
    {
        public LanguageAddCommandValidator()
        {
            RuleFor(command => command.Name).MinimumLength(1).WithMessage("'name' is too short.")
                                            .MaximumLength(64).WithMessage("'name' is too long.")
                                            .OverridePropertyName("name");
        }
    }
}
