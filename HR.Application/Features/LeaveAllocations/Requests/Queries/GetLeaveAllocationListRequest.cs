using HR.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
