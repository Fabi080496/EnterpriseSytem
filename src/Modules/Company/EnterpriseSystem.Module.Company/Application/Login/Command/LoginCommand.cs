using MediatR;
namespace EnterpriseSystem.Module.Organization.Application.Login.Command
{
    public record LoginCommand(string Email, string Password)
        : IRequest<LoginResult>; 
}
