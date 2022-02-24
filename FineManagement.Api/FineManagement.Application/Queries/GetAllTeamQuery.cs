using FineManagement.Core.Entities;
using MediatR;

namespace FineManagement.Application.Queries
{
    public class GetAllTeamQuery : IRequest<List<Team>>
    {
    }
}
