
namespace EnterpriseSystem.Module.Organization.Application.Login.Command
{
    public record LoginResult(
        string Token,
        DateTime ExpiresAt);
}
