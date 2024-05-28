using HR.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestDto>>
    {
    }
}
