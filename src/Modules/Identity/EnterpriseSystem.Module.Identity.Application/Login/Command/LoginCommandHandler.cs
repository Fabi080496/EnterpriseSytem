using EnterpriseSystem.Module.Identity.Application.Security;
using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Login.Command
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, string>
    {
        private readonly IJwtTokenGenerator _jwt;

        public LoginCommandHandler(IJwtTokenGenerator jwt)
        {
            _jwt = jwt;
        }

        public async Task<string> Handle(LoginCommand request,CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();

            return _jwt.Generate(userId, request.Email);
        }
    }
}
