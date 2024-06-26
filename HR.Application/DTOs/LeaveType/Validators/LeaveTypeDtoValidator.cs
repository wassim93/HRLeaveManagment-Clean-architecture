﻿using FluentValidation;

namespace HR.Application.DTOs.LeaveType.Validators
{
    public class LeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public LeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisionValue} characters");

            RuleFor(p => p.DefaultDays)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .GreaterThan(0).WithMessage("{PropertyName} must be at least 1")
               .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisionValue}");

        }
    }
}
