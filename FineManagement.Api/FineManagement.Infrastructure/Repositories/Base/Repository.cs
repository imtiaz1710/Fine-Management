using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using FineManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FineManagement.Infrastructure.Repositories.Base
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly FineManagementDbContext _fineManagementDbContext;

        public Repository(FineManagementDbContext fineManagementDbContext)
        {
            _fineManagementDbContext = fineManagementDbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _fineManagementDbContext.Set<TEntity>().AddAsync(entity);
            await _fineManagementDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TKey id)
        {
            var entityToDelete = await _fineManagementDbContext.Set<TEntity>().FindAsync(id);
            _fineManagementDbContext.Set<TEntity>().Remove(entityToDelete);

            await _fineManagementDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _fineManagementDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _fineManagementDbContext.Set<TEntity>().Update(entity);
            await _fineManagementDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
