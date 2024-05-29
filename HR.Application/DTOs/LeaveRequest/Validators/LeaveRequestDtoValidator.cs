using FluentValidation;
using HR.Application.Persistance.Contracts;

namespace HR.Application.DTOs.LeaveRequest.Validators
{
    public class LeaveRequestDtoValidator : AbstractValidator<LeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
               .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisionValue}");

            RuleFor(p => p.EndDate)
               .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be before {ComparisionValue}");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypesExist = await _leaveTypeRepository.Exists(id);
                    return !leaveTypesExist;

                })
                .WithMessage("{PropertyName} does not exist");
        }
    }
}
