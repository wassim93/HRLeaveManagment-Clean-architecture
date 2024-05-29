using AutoMapper;
using HR.Application.Features.LeaveAllocations.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;
        private readonly Mapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepositroy leaveAllocationRepositroy, Mapper mapper)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.leaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepositroy.Add(leaveAllocation);
            return leaveAllocation.Id;
        }
    }
}
