﻿namespace HR.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
