﻿using HR.Application.DTOs.Common;
using HR.Application.DTOs.LeaveType;

namespace HR.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
