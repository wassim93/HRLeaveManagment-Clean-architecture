using FluentValidation;

namespace HR.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
