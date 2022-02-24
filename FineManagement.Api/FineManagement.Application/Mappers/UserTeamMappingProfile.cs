using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;

namespace FineManagement.Application.Mappers
{
    public class UserTeamMappingProfile : Profile
    {
        public UserTeamMappingProfile()
        {
            CreateMap<UserTeam, AddOrUpdateUserTeamCommand>().ReverseMap();
            CreateMap<UserTeam, UserTeamResponse>().ReverseMap();
        }
    }
}
