﻿using HR.Application.DTOs.LeaveType;
using MediatR;

namespace HR.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
