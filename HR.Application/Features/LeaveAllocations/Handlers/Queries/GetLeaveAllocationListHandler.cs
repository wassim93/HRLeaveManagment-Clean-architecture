using AutoMapper;
using HR.Application.DTOs;
using HR.Application.Features.LeaveAllocations.Requests.Queries;
using HR.Application.Persistance.Contracts;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListHandler(ILeaveAllocationRepositroy leaveAllocationRepositroy, IMapper mapper)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeAllocations = await _leaveAllocationRepositroy.GetAll();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveTypeAllocations);
        }
    }
}
