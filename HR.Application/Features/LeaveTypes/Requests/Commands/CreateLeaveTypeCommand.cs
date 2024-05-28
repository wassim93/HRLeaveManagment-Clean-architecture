using HR.Application.DTOs.LeaveType;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public LeaveTypeDto leaveTypeDto { get; set; }
    }
}
