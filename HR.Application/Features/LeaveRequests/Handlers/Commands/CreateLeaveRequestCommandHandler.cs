using AutoMapper;
using HR.Application.DTOs.LeaveRequest.Validators;
using HR.Application.Features.LeaveRequests.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Application.Responses;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandReponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly Mapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, Mapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandReponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandReponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.leaveRequestDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.leaveRequestDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = leaveRequest.Id;
            return response;
        }
    }
}
