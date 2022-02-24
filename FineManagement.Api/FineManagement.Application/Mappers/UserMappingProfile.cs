using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;

namespace FineManagement.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, AddOrUpdateUserCommand>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
        }
    }
}
