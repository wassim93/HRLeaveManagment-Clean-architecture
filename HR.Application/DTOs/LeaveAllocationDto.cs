using HR.Application.DTOs.Common;

namespace HR.Application.DTOs
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
