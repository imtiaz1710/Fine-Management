﻿using AutoMapper;
using FineManagement.Application.Commands;
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
    public class DeleteHandler<TCommand, TRepository, TEntity> : IRequestHandler<TCommand, int>
        where TCommand : IRequest<int>
        where TRepository : IRepository<TEntity>
        where TEntity : class, IEntity<int>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public DeleteHandler(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request);
            await _repository.DeleteAsync(entity);
            return entity.Id;
        }
    }
}
