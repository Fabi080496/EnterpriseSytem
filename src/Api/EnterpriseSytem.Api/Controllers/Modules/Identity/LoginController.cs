using EnterpriseSystem.Module.Identity.Application.Login.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSytem.Api.Controllers.Modules.Identity
{
    [ApiController]
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<LoginResult> Login([FromBody] LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return token;
        }
    }
}
