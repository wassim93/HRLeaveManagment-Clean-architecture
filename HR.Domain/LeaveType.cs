using HR.Domain.Common;

namespace HR.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
