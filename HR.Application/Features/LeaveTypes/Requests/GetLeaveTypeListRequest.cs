using HR.Application.DTOs;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Requests
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
