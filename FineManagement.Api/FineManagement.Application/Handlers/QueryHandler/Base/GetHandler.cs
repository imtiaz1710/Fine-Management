using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FineManagement.Application.Handlers.QueryHandler.Base
{
    public class GetHandler<TQuery, TResponse, TRepository, TEntity> : IRequestHandler<TQuery, TResponse>
        where TQuery : IRequest<TResponse>
        where TEntity : class, IEntity<int>
        where TRepository : IRepository<TEntity>
        where TResponse: IEnumerable<TEntity>
    {
        private readonly TRepository _repository;

        public GetHandler(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
        {
            return (TResponse)await _repository.GetAllAsync();
        }
    }
}
