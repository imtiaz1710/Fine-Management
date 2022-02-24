using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Handlers.CommandHandlers.Base;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories;

namespace FineManagement.Application.Handlers.CommandHandlers
{
    public class AddUserHandler : CreateHandler<AddOrUpdateUserCommand, UserResponse, IUserRepository, User>
    {
        public AddUserHandler(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
        {
        }
    }
}
