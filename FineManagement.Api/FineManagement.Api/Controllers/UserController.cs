using AutoMapper;
using FineManagement.Application.Commands;
using FineManagement.Core.Entities;
using FineManagement.Core.Repositories.Base;
using MediatR;
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
            await _repository.AddAsync(entity);
            return Ok(entity);
        }

        
    }
}
