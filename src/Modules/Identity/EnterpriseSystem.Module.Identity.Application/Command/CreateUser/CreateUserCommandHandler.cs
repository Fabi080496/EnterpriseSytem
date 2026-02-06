using EnterpriseSystem.Module.Identity.Domain.Domain;
using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using MediatR;
using System.Xml.Linq;

namespace EnterpriseSystem.Module.Identity.Application.Command.User_Create
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User(Guid.NewGuid(),request.Name,request.LastName,request.DocumentType,request.DocumentNumber, request.Email);
            await _repository.AddAsync(user);
            return user.Id;
        }
    }
}
