namespace EnterpriseSystem.Module.Organization.Domain.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string email);
    }
}
