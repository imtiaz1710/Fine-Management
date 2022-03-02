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
    public class FineController : ControllerBase
    {
        private readonly IRepository<Fine, int> _repository;
        private IMapper _mapper;

        public FineController(IRepository<Fine, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateFineCommand command)
        {
            var entity = _mapper.Map<Fine>(command);
            var returnedEntity = await _repository.AddAsync(entity);

            return Ok(_mapper.Map<FineResponse>(returnedEntity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddOrUpdateFineCommand command)
        {
            var entity = _mapper.Map<Fine>(command);
            entity.Id = id;
            var responseEntity = await _repository.UpdateAsync(entity);

            return Ok(_mapper.Map<FineResponse>(responseEntity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fineListEntity = await _repository.GetAllAsync();
            var fineListResponse = new List<FineResponse>();

            foreach (var Fine in fineListEntity)
            {
                fineListResponse.Add(_mapper.Map<FineResponse>(Fine));
            }

            return Ok(fineListResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok(id);
        }
    }
}
