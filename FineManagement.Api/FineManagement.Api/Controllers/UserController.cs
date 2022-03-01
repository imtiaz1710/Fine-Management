using FineManagement.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FineManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrUpdateUserCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
