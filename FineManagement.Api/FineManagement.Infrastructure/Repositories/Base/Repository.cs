using FineManagement.Core.Repositories.Base;
using FineManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FineManagement.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FineManagementDbContext _fineManagementDbContext;

        public Repository(FineManagementDbContext fineManagementDbContext)
        {
            _fineManagementDbContext = fineManagementDbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _fineManagementDbContext.Set<T>().AddAsync(entity);
            await _fineManagementDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _fineManagementDbContext.Set<T>().Remove(entity);
            await _fineManagementDbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _fineManagementDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _fineManagementDbContext.Set<T>().Update(entity);
            await _fineManagementDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
