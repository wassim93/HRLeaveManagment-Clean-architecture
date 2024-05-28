namespace HR.Application.Persistance.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
