using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;

namespace FineManagement.Application.Mappers
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<Team, AddOrUpdateTeamCommand>().ReverseMap();
            CreateMap<Team, TeamResponse>().ReverseMap();
        }
    }
}
