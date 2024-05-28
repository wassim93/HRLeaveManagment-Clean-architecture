using HR.Domain;

namespace HR.Application.Persistance.Contracts
{
    public interface ILeaveAllocationRepositroy : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
    }
}
