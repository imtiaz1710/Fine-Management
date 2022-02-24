using FineManagement.Application.Responses;
using MediatR;

namespace FineManagement.Application.Commands
{
    public class AddOrUpdateUserTeamCommand : IRequest<UserTeamResponse>
    {
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}
