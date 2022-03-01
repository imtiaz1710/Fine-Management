using AutoMapper;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using MediatR;

namespace FineManagement.Application.Handlers.CommandHandlers.Base
{
    public class CreateHandler<TCommand, TResponse, TRepository, TEntity> : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
        where TEntity : BaseEntity<object>
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public CreateHandler(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            var newEntity = await _repository.AddAsync(entity);
            var response = _mapper.Map<TResponse>(newEntity);

            return response;
        }
    }
}
