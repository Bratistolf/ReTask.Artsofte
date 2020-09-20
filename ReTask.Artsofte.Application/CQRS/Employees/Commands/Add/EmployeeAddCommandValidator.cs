using FluentValidation;

namespace ReTask.Artsofte.Application.CQRS.Employees.Commands.Add
{
    public class EmployeeAddCommandValidator : AbstractValidator<EmployeeAddCommand>
    {
        public EmployeeAddCommandValidator()
        {
            RuleFor(command => command.Name).MaximumLength(128).WithMessage("Имя не может быть длиннее 128 символов.")
                                            .MinimumLength(1).WithMessage("Имя не может быть короче 1 символа.")
                                            .OverridePropertyName("name");

            RuleFor(command => command.Surname).MaximumLength(128).WithMessage("Фамилия не может быть длиннее 128 символов.")
                                               .MinimumLength(1).WithMessage("Фамилия не может быть короче 1 символа.")
                                               .OverridePropertyName("surname");

            RuleFor(command => command.Age).LessThanOrEqualTo(128).WithMessage("Возраст не может быть больше 128 лет.")
                                           .GreaterThanOrEqualTo(14).WithMessage("Возраст не может быть меньше 14 лет.")
                                           .OverridePropertyName("age");
        }
    }
}
