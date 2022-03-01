using FineManagement.Core.Entities;

namespace FineManagement.Core.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : BaseEntity<int>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
