using AutoMapper;
using HR.Application.Features.LeaveTypes.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);
            return leaveType.Id;

        }
    }
}
