using AutoMapper;
using FineManagement.Core.Repositories.Base;
using MediatR;

namespace FineManagement.Application.Handlers.CommandHandlers.Base
{
    public class CreateHandler<TCommand, TResponse, TRepository, TEntity> : IRequestHandler<TCommand, TResponse>
        where TCommand : MediatR.IRequest<TResponse>
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateHandler(TRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<TEntity>(request);
            var newUser = await _userRepository.AddAsync(userEntity);
            var userResponse = _mapper.Map<TResponse>(newUser);

            return userResponse;
        }
    }
}
