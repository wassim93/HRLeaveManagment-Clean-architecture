using HR.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }

    }
}
