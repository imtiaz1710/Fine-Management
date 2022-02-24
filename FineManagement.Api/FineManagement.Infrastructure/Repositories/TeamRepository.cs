using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories.Base;

namespace FineManagement.Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(FineManagementDbContext fineManagementDbContext) : base(fineManagementDbContext)
        {
        }
    }
}
