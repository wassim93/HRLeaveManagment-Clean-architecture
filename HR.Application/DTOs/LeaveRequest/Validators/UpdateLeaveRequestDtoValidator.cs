using FluentValidation;

namespace HR.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}
