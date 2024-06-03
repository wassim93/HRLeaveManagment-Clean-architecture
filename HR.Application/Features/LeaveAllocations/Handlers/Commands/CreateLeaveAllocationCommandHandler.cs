using AutoMapper;
using HR.Application.DTOs.LeaveAllocation.Validators;
using HR.Application.Features.LeaveAllocations.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Application.Responses;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandReponse>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;
        private readonly Mapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepositroy leaveAllocationRepositroy, Mapper mapper)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;
            _mapper = mapper;
        }
        public async Task<BaseCommandReponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandReponse();

            var validator = new CreateLeaveAllocationDtoValidator(_leaveAllocationRepositroy);
            var validationResult = await validator.ValidateAsync(request.leaveAllocationDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.leaveAllocationDto);
            leaveAllocation = await _leaveAllocationRepositroy.Add(leaveAllocation);
            response.Success = true;
            response.Message = "Creation successful";
            response.Id = leaveAllocation.Id;
            return response;
        }
    }
}
