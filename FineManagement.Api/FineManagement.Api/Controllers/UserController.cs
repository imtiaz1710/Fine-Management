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
        private readonly IRepository<User> _repository;
        private IMapper _mapper;

        public UserController(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateUserCommand command)
        {
            var entity = _mapper.Map<User>(command);
            return Ok(await _repository.AddAsync(entity));
        }
    }
}
