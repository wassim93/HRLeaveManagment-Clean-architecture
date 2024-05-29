using HR.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto leaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto { get; set; }
    }
}
