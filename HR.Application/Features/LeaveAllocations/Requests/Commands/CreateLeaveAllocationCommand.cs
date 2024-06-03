using HR.Application.DTOs.LeaveAllocation;
using HR.Application.Responses;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<BaseCommandReponse>
    {
        public CreateLeaveAllocationDto leaveAllocationDto { get; set; }
    }
}
