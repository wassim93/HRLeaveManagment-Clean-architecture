using HR.Application.Persistance.Contracts;
using HR.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagmentDBContext leaveManagmentDBContext;

        public LeaveRequestRepository(LeaveManagmentDBContext leaveManagmentDBContext) : base(leaveManagmentDBContext)
        {
            this.leaveManagmentDBContext = leaveManagmentDBContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approved)
        {
            leaveRequest.Approved = approved;
            this.leaveManagmentDBContext.Entry(leaveRequest).State = EntityState.Modified;
            await this.leaveManagmentDBContext.SaveChangesAsync();

        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await this.leaveManagmentDBContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await this.leaveManagmentDBContext.LeaveRequests
                 .Include(q => q.LeaveType)
                 .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }
    }
}
