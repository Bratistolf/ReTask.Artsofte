using FluentValidation;

namespace ReTask.Artsofte.Application.CQRS.Employees.Commands.Edit
{
    public class EmployeeEditCommandValidator : AbstractValidator<EmployeeEditCommand>
    {
        public EmployeeEditCommandValidator()
        {
            RuleFor(command => command.Name).MaximumLength(128).WithMessage("")
                                            .MinimumLength(1).WithMessage("")
                                            .OverridePropertyName("name");

            RuleFor(command => command.Surname).MaximumLength(128).WithMessage("")
                                               .MinimumLength(1).WithMessage("")
                                               .OverridePropertyName("surname");

            RuleFor(command => command.Age).LessThanOrEqualTo(128).WithMessage("")
                                           .GreaterThanOrEqualTo(14).WithMessage("")
                                           .OverridePropertyName("age");

            RuleFor(command => command.Gender).IsInEnum().WithMessage("")
                                              .OverridePropertyName("gender");
        }
    }
}
