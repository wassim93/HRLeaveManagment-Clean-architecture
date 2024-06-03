using AutoMapper;
using HR.Application.Exceptions;
using HR.Application.Features.LeaveRequests.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly Mapper _mapper;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, Mapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundEception(nameof(LeaveRequest), request.Id);
            }
            await _leaveRequestRepository.Delete(leaveRequest);
            return Unit.Value;
        }
    }
}
