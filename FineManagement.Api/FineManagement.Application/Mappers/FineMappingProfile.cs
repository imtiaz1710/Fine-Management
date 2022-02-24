using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;

namespace FineManagement.Application.Mappers
{
    public class FineMappingProfile : Profile
    {
        public FineMappingProfile()
        {
            CreateMap<Fine, AddOrUpdateFineCommand>().ReverseMap();
            CreateMap<Fine, FineResponse>().ReverseMap();
        }
    }
}
