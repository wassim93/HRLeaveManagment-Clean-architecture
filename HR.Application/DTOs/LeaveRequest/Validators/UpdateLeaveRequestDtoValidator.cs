using FluentValidation;
using HR.Application.DTOs.LeaveAllocation;

namespace HR.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        public UpdateLeaveRequestDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
