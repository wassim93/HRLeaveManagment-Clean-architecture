using FluentValidation;

namespace HR.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveAllocationDto : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveAllocationDto()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
