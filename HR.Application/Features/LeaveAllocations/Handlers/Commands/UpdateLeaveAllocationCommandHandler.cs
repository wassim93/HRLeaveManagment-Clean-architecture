﻿using AutoMapper;
using HR.Application.DTOs.LeaveAllocation.Validators;
using HR.Application.Exceptions;
using HR.Application.Features.LeaveAllocations.Requests.Commands;
using HR.Application.Persistance.Contracts;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;
        private readonly Mapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepositroy leaveAllocationRepositroy, Mapper mapper)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }
            var leaveAllocation = await _leaveAllocationRepositroy.Get(request.LeaveAllocationDto.Id);
            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepositroy.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
