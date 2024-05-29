using HR.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public CreateLeaveRequestDto leaveRequestDto { get; set; }
    }
}
