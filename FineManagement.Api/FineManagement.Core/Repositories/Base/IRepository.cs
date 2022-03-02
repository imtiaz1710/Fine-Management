using FineManagement.Core.Entities;

namespace FineManagement.Core.Repositories.Base
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
