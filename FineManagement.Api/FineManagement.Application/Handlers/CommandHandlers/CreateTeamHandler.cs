using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Handlers.CommandHandlers.Base;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;

namespace FineManagement.Application.Handlers.CommandHandlers
{
    public class CreateTeamHandler : CreateHandler<AddOrUpdateTeamCommand, TeamResponse, ITeamRepository, Team>
    {
        public CreateTeamHandler(ITeamRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
        }
    }
}
