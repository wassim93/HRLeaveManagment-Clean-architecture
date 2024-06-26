﻿using AutoMapper;
using HR.Application.Exceptions;
using HR.Application.Features.LeaveAllocations.Requests.Commands;
using HR.Application.Persistance.Contracts;
using HR.Domain;
using MediatR;

namespace HR.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepositroy _leaveAllocationRepositroy;
        private readonly Mapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepositroy leaveAllocationRepositroy, Mapper mapper)
        {
            _leaveAllocationRepositroy = leaveAllocationRepositroy;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leavAllocation = await _leaveAllocationRepositroy.Get(request.Id);
            if (leavAllocation == null)
            {
                throw new NotFoundEception(nameof(LeaveAllocation), request.Id);
            }
            await _leaveAllocationRepositroy.Delete(leavAllocation);
            return Unit.Value;
        }
    }
}
