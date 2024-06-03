using HR.Application.DTOs.LeaveRequest;
using HR.Application.Responses;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandReponse>
    {
        public CreateLeaveRequestDto leaveRequestDto { get; set; }
    }
}
