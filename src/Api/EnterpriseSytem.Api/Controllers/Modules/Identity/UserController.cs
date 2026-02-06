using EnterpriseSystem.Module.Identity.Application.User.Command.Create;
using EnterpriseSystem.Module.Identity.Application.User.Querys.GetBy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSytem.Api.Controllers.Modules.Identity
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user is null)
                return NotFound();

            return Ok(user);
        }
    }
}


