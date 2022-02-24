using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;
using FineManagement.Infrastructure.Data;
using FineManagement.Infrastructure.Repositories.Base;

namespace FineManagement.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(FineManagementDbContext fineManagementDbContext) : base(fineManagementDbContext)
        {
        }
    }
}
