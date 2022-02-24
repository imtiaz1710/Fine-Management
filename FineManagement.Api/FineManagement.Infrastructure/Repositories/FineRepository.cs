using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories.Base;

namespace FineManagement.Infrastructure.Repositories
{
    public class FineRepository : Repository<Fine>, IFineRepository
    {
        public FineRepository(FineManagementDbContext fineManagementDbContext) : base(fineManagementDbContext)
        {
        }
    }
}
