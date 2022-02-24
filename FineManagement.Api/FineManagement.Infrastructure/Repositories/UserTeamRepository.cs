using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories.Base;

namespace FineManagement.Infrastructure.Repositories
{
    public class UserTeamRepository : Repository<UserTeam>, IUserTeamRepository
    {
        public UserTeamRepository(FineManagementDbContext fineManagementDbContext) : base(fineManagementDbContext)
        {
        }
    }
}
