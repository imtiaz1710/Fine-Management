using FineManagement.Core.Entities;
using MediatR;

namespace FineManagement.Application.Queries
{
    public class GetAllUserQuery : IRequest<List<User>>
    {
    }
}
