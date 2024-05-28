using HR.Application.DTOs.Common;
using HR.Application.DTOs.LeaveType;

namespace HR.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
