using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.User.Command.Create
{
    public record CreateUserCommand(string Name,string LastName, string DocumentType, string DocumentNumber,string Email)
        : IRequest<Guid>;
}
