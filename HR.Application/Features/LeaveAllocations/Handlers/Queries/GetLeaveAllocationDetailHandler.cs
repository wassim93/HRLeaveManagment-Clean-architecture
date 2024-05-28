using AutoMapper;
using HR.Application.DTOs;
using HR.Application.Features.LeaveAllocations.Requests.Queries;
using HR.Application.Persistance.Contracts;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailHandler(ILeaveAllocationRepositroy leaveAllocationRepositroy, IMapper mapper)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepositroy.Get(request.Id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
        }
    }
}
