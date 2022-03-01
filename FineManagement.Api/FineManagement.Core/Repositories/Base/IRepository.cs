namespace FineManagement.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
