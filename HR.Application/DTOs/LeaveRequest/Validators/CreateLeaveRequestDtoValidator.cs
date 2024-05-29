using FluentValidation;
using HR.Application.Persistance.Contracts;

namespace HR.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisionValue}");

            RuleFor(p => p.EndDate)
               .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be before {ComparisionValue}");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) =>
            {
                var leaveTypesExist = await _leaveRequestRepository.Exists(id);
                return !leaveTypesExist;

            })
                .WithMessage("{PropertyName} does not exist");
        }
    }
}
