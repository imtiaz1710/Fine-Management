using FineManagement.Core.Entities;
using MediatR;

namespace FineManagement.Application.Queries
{
    public class GetAllUserTeamQuery : IRequest<List<UserTeam>>
    {
    }
}
