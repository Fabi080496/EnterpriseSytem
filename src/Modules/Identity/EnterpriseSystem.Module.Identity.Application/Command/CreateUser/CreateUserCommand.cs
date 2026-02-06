using MediatR;

namespace EnterpriseSystem.Module.Identity.Application.Command
{
    public record CreateUserCommand(string Email)
        : IRequest<Guid>;
}
