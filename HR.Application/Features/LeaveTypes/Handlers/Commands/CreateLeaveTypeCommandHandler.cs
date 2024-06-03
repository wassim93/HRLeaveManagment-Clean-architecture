using AutoMapper;
using HR.Application.DTOs.LeaveType.Validators;
using HR.Application.Features.LeaveTypes.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Application.Responses;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandReponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandReponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandReponse();

            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveTypeDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            var leaveType = _mapper.Map<LeaveType>(request.leaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = leaveType.Id;
            return response;

        }
    }
}
