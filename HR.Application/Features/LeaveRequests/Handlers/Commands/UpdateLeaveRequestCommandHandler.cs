using AutoMapper;
using HR.Application.DTOs.LeaveRequest.Validators;
using HR.Application.Exceptions;
using HR.Application.Features.LeaveRequests.Requests.Commands;
using HR.Application.Persistance.Contracts;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly Mapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, Mapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveRequestDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.leaveRequestDto != null)
            {
                _mapper.Map(request.leaveRequestDto, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.changeLeaveRequestApprovalDto != null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.changeLeaveRequestApprovalDto.Approved);
            }


            return Unit.Value;
        }


    }
}
