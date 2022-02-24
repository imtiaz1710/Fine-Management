using FineManagement.Application.Responses;
using MediatR;

namespace FineManagement.Application.Commands
{
    public class AddOrUpdateTeamCommand : IRequest<TeamResponse>
    {
        public string? Name { get; set; }
    }
}
