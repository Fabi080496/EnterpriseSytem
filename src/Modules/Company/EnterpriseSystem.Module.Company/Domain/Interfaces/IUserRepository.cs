using EnterpriseSystem.Module.Organization.Domain.Entities;

namespace EnterpriseSystem.Module.Organization.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email, CancellationToken ct);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken);

    }
}
