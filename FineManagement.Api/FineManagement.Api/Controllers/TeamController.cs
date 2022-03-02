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
    public class TeamController : ControllerBase
    {
        private readonly IRepository<Team, int> _repository;
        private IMapper _mapper;

        public TeamController(IRepository<Team, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateTeamCommand command)
        {
            var entity = _mapper.Map<Team>(command);
            var returnedEntity = await _repository.AddAsync(entity);

            return Ok(_mapper.Map<TeamResponse>(returnedEntity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddOrUpdateTeamCommand command)
        {
            var entity = _mapper.Map<Team>(command);
            entity.Id = id;
            var responseEntity = await _repository.UpdateAsync(entity);

            return Ok(_mapper.Map<TeamResponse>(responseEntity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teamListEntity = await _repository.GetAllAsync();
            var teamListResponse = new List<TeamResponse>();

            foreach (var Team in teamListEntity)
            {
                teamListResponse.Add(_mapper.Map<TeamResponse>(Team));
            }

            return Ok(teamListResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok(id);
        }
    }
}
