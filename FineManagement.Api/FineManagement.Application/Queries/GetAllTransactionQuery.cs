using FineManagement.Core.Entities;
using MediatR;

namespace FineManagement.Application.Queries
{
    public class GetAllTransactionQuery : IRequest<List<Transaction>>
    {
    }
}
