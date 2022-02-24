using FineManagement.Core.Entities;
using MediatR;

namespace FineManagement.Application.Queries
{
    public class GetAllFineQuery : IRequest<List<Fine>>
    {
    }
}
