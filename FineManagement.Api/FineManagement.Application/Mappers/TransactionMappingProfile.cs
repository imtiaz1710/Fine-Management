using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;

namespace FineManagement.Application.Mappers
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<Transaction, AddOrUpdateTransactionCommand>().ReverseMap();
            CreateMap<Transaction, TransactionResponse>().ReverseMap();
        }
    }
}
