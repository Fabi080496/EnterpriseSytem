using EnterpriseSystem.Module.Identity.Domain.Entities;

namespace EnterpriseSystem.Module.Identity.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email, CancellationToken ct);

    }
}
