namespace EnterpriseSystem.Module.Identity.Application.Security
{
    public interface IJwtTokenGenerator
    {
        string Generate(Guid userId, string email);
    }
}
