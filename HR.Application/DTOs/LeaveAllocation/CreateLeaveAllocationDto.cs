using HR.Application.DTOs.Common;

namespace HR.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
