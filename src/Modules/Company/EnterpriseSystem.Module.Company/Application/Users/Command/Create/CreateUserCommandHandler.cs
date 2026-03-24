using EnterpriseSystem.Module.Organization.Domain.Entities;
using EnterpriseSystem.Module.Organization.Domain.Interfaces;
using EnterpriseSystem.Module.Organization.Domain.Interfaces.Security;
using EnterpriseSystem.Shared.Exceptions;
using MediatR;

namespace EnterpriseSystem.Module.Organization.Application.Users.Command.Create
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository,IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher= passwordHasher;
        }

        public async Task<Guid> Handle( CreateUserCommand request,CancellationToken cancellationToken)
        {
            if (await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken))
            {
                throw new BadRequestException("El correo ya está registrado");
            }

            var passwordHash = _passwordHasher.Hash(request.Password);

            var user = User.Create(
                request.Name,
                request.LastName,
                request.DocumentType,
                request.DocumentNumber,
                request.Email,
                passwordHash);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
