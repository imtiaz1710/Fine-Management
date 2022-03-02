using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Application.Responses;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace FineManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Transaction, int> _repository;
        private IMapper _mapper;

        public TransactionController(IRepository<Transaction, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateTransactionCommand command)
        {
            var entity = _mapper.Map<Transaction>(command);
            var returnedEntity = await _repository.AddAsync(entity);

            return Ok(_mapper.Map<TransactionResponse>(returnedEntity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddOrUpdateTransactionCommand command)
        {
            var entity = _mapper.Map<Transaction>(command);
            entity.Id = id;
            var responseEntity = await _repository.UpdateAsync(entity);

            return Ok(_mapper.Map<TransactionResponse>(responseEntity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactionListEntity = await _repository.GetAllAsync();
            var transactionListResponse = new List<TransactionResponse>();

            foreach (var Transaction in transactionListEntity)
            {
                transactionListResponse.Add(_mapper.Map<TransactionResponse>(Transaction));
            }

            return Ok(transactionListResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok(id);
        }
    }
}
