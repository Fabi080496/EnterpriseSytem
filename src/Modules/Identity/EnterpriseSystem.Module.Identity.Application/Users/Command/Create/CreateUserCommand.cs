using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Users.Command.Create
{
    public record CreateUserCommand(string Name,string LastName, string DocumentType, string DocumentNumber,string Email,string Password)
        : IRequest<Guid>;
}
