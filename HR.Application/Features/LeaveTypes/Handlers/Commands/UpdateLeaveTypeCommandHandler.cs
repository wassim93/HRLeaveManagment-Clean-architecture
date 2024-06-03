using AutoMapper;
using HR.Application.DTOs.LeaveType.Validators;
using HR.Application.Exceptions;
using HR.Application.Features.LeaveTypes.Requests.Commands;
using HR.Application.Persistance.Contracts;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.leaveTypeDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            var leaveType = await _leaveTypeRepository.Get(request.leaveTypeDto.Id);
            _mapper.Map(request.leaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }
    }
}
