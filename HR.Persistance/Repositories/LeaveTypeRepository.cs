using HR.Application.Persistance.Contracts;
using HR.Domain;

namespace HR.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagmentDBContext leaveManagmentDBContext;

        public LeaveTypeRepository(LeaveManagmentDBContext leaveManagmentDBContext) : base(leaveManagmentDBContext)
        {
            this.leaveManagmentDBContext = leaveManagmentDBContext;
        }
    }
}
