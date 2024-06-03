using HR.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HR.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagmentDBContext _leaveManagmentDBContext;

        public GenericRepository(LeaveManagmentDBContext leaveManagmentDBContext)
        {
            _leaveManagmentDBContext = leaveManagmentDBContext;
        }
        public async Task<T> Add(T entity)
        {
            await _leaveManagmentDBContext.AddAsync(entity);
            await _leaveManagmentDBContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _leaveManagmentDBContext.Set<T>().Remove(entity);
            await _leaveManagmentDBContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entiry = await Get(id);
            return entiry != null;
        }

        public async Task<T> Get(int id)
        {
            return await _leaveManagmentDBContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _leaveManagmentDBContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _leaveManagmentDBContext.Entry(entity).State = EntityState.Modified;
            await _leaveManagmentDBContext.SaveChangesAsync();
        }
    }
}
