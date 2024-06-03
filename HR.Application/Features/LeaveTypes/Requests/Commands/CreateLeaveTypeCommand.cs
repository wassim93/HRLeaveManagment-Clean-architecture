using HR.Application.DTOs.LeaveType;
using HR.Application.Responses;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandReponse>
    {
        public CreateLeaveTypeDto leaveTypeDto { get; set; }
    }
}
