using FluentValidation;
using HR.Application.Persistance.Contracts;

namespace HR.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;

        public CreateLeaveAllocationDtoValidator(ILeaveAllocationRepositroy leaveAllocationRepositroy)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;

            RuleFor(p => p.LeaveTypeID)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypesExist = await _leaveAllocationRepositroy.Exists(id);
                    return !leaveTypesExist;

                })
                .WithMessage("{PropertyName} does not exist");
        }
    }
}
