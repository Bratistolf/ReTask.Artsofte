using FluentValidation;
using ReTask.Artsofte.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReTask.Artsofte.Application.CQRS.Employees.Commands.Add
{
    public class EmployeeAddCommandValidator : AbstractValidator<EmployeeAddCommand>
    {
        public EmployeeAddCommandValidator()
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
