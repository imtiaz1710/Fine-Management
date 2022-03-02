using AutoMapper;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineManagement.Application.Handlers.CommandHandlers.Base
{
    public class UpdateHandler<TCommand, TResponse, TRepository, TEntity, TKey> : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
        where TEntity : BaseEntity<TKey>
        where TRepository : IRepository<TEntity, TKey>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public UpdateHandler(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            var newEntity = await _repository.UpdateAsync(entity);
            var response = _mapper.Map<TResponse>(newEntity);

            return response;
        }
    }
}
