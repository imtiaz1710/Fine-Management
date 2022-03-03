using AutoMapper;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using MediatR;

namespace FineManagement.Application.Handlers.CommandHandlers.Base
{
    public class DeleteHandler<TCommand, TRepository, TEntity, TKey> : IRequestHandler<TCommand, TKey>
       where TCommand : IRequest<TKey>
        where TRepository : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public DeleteHandler(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TKey> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            await _repository.DeleteAsync(entity.Id);
            return entity.Id;
        }
    }
}
