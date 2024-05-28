using HR.Domain.Common;

namespace HR.Domain
{
    public class LeaveAllocation : BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeID { get; set; }
        public int Period { get; set; }
    }
}
