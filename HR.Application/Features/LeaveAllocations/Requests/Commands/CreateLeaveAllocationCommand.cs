using HR.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto leaveAllocationDto { get; set; }
    }
}
