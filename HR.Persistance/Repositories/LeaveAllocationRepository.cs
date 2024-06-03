using HR.Application.Persistance.Contracts;
using HR.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepositroy
    {
        private readonly LeaveManagmentDBContext leaveManagmentDBContext;

        public LeaveAllocationRepository(LeaveManagmentDBContext leaveManagmentDBContext) : base(leaveManagmentDBContext)
        {
            this.leaveManagmentDBContext = leaveManagmentDBContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leavaAllocations = await this.leaveManagmentDBContext.LeaveAllocations
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leavaAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await this.leaveManagmentDBContext.LeaveAllocations
                 .Include(q => q.LeaveType)
                 .FirstOrDefaultAsync(q => q.Id == id);
            return leaveAllocation;
        }
    }
}
