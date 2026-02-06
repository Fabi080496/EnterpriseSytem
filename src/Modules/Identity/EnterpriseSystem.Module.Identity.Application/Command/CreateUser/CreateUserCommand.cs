using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Command
{
    public record CreateUserCommand(string Name,string LastName, string DocumentType, string DocumentNumber,string Email)
        : IRequest<Guid>;
}
