using AutoMapper;
using HR.Application.DTOs.LeaveType;
using HR.Application.Features.LeaveTypes.Requests.Queries;
using HR.Application.Persistance.Contracts;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
