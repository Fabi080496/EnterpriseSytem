using EnterpriseSystem.Module.Organization.Domain.Interfaces.Security;
using Microsoft.AspNetCore.Identity;

namespace EnterpriseSystem.Module.Organization.Infraestructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string password)
            => _hasher.HashPassword(null!, password);

        public bool Verify(string password, string hash)
            => _hasher.VerifyHashedPassword(
                null!, hash, password)
               == PasswordVerificationResult.Success;
    }
}
