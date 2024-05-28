using HR.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }

    }
}
