namespace EnterpriseSystem.Shared.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string email);
    }
}
