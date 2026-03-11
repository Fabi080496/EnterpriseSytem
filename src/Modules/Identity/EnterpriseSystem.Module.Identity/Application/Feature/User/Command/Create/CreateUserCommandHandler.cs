using EnterpriseSystem.Module.Identity.Domain.Entities;
using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using EnterpriseSystem.Shared.Security;
using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Users.Command.Create
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository repository,IPasswordHasher passwordHasher)
        {
            _repository = repository;
            _passwordHasher= passwordHasher;
        }

        public async Task<Guid> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {

            var passwordHash = _passwordHasher.Hash(request.Password);
            var user = User.Create(
                request.Name,
                request.LastName,
                request.DocumentType,
                request.DocumentNumber,
                request.Email,
                passwordHash);

            await _repository.AddAsync(user);

            return user.Id;
        }
    }
}
