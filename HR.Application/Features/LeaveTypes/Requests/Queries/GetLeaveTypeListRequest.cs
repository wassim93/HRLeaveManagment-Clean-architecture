using HR.Application.DTOs.LeaveType;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
