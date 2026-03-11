using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using EnterpriseSystem.Shared.Security;
using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Login.Command
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IJwtTokenGenerator _jwt;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public LoginCommandHandler(IJwtTokenGenerator jwt,IPasswordHasher passwordHasher, IUserRepository userRepository)
        {
            _jwt = jwt;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<LoginResult> Handle(LoginCommand request,CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByEmailAsync(request.Email, cancellationToken);

            if (user is null)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            if (!_passwordHasher.Verify(
                request.Password,
                user.Password))
                throw new UnauthorizedAccessException("Credenciales inválidas");

            var token = _jwt.GenerateToken(
                user.Id,
                user.Email);

            return new LoginResult(
                token,
                DateTime.UtcNow.AddMinutes(60)
                );

        }
    }
}
