using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Handlers.CommandHandlers.Base;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;

namespace FineManagement.Application.Handlers.CommandHandlers
{
    public class CreateFineHandler : CreateHandler<AddOrUpdateTeamCommand, TeamResponse, IFineRepository, Fine>
    {
        public CreateFineHandler(IFineRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
        }
    }
}
