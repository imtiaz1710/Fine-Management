using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories.Base;

namespace FineManagement.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FineManagementDbContext fineManagementDbContext) : base(fineManagementDbContext)
        {
        }
    }
}
