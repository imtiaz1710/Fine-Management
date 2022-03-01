using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using FineManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FineManagement.Infrastructure.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<int>
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

        public async Task DeleteAsync(TEntity entity)
        {
            _fineManagementDbContext.Set<TEntity>().Remove(entity);
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
