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
    public class UserTeamController : ControllerBase
    {
        private readonly IRepository<UserTeam, int> _repository;
        private IMapper _mapper;

        public UserTeamController(IRepository<UserTeam, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateUserTeamCommand command)
        {
            var entity = _mapper.Map<UserTeam>(command);
            var returnedEntity = await _repository.AddAsync(entity);

            return Ok(_mapper.Map<UserTeamResponse>(returnedEntity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddOrUpdateUserTeamCommand command)
        {
            var entity = _mapper.Map<UserTeam>(command);
            entity.Id = id;
            var responseEntity = await _repository.UpdateAsync(entity);

            return Ok(_mapper.Map<UserTeamResponse>(responseEntity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userTeamListEntity = await _repository.GetAllAsync();
            var userTeamListResponse = new List<UserTeamResponse>();

            foreach (var UserTeam in userTeamListEntity)
            {
                userTeamListResponse.Add(_mapper.Map<UserTeamResponse>(UserTeam));
            }

            return Ok(userTeamListResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok(id);
        }
    }
}
