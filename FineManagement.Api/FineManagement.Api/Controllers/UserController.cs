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
    public class UserController : ControllerBase
    {
        private readonly IRepository<User, int> _repository;
        private IMapper _mapper;

        public UserController(IRepository<User, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateUserCommand command)
        {
            var entity = _mapper.Map<User>(command);
            var returnedEntity = await _repository.AddAsync(entity);

            return Ok(_mapper.Map<UserResponse>(returnedEntity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddOrUpdateUserCommand command)
        {
            var entity = _mapper.Map<User>(command);
            entity.Id = id;
            var responseEntity = await _repository.UpdateAsync(entity);

            return Ok(_mapper.Map<UserResponse>(responseEntity));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userListEntity = await _repository.GetAllAsync();
            var userListResponse = new List<UserResponse>();

            foreach (var user in userListEntity)
            {
                userListResponse.Add(_mapper.Map<UserResponse>(user));
            }

            return Ok(userListResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok(id);
        }
    }
}
